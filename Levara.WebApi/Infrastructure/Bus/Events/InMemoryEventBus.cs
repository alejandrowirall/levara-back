using Levara.Domain.Contexts;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Events;
using Levara.Shared.Infrastructure.OperationScopes;
using Levara.WebApi.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Threading.Channels;

namespace Levara.WebApi.Infrastructure.Bus.Events
{
    public class InMemoryEventBus : IEventBus
    {
        private readonly IUserContext _userContext;
        private readonly BackgroundQueue _backgroundQueue;
        public InMemoryEventBus(IUserContext userContext,
            BackgroundQueue backgroundQueue)
        {
            _userContext = userContext;
            _backgroundQueue = backgroundQueue;
        }
        public async Task PublishAsync(List<IDomainEvent> events)
        {
            var userContext = _userContext; // Inyectado en tu EventBus

            var snapshot = new SnapshotUserContext();
            snapshot.Initialize(userContext);

            await Task.Delay(2000);

            foreach (var @event in events)
            {
                await _backgroundQueue.EnqueueAsync(async (cancellationToken, scope) =>
                {

                    IDomainEventConsumer _domainEventConsumer = scope.ServiceProvider.GetService<IDomainEventConsumer>();
                    ILogger<InMemoryEventBus> _logger = scope.ServiceProvider.GetService<ILogger<InMemoryEventBus>>();
                    IUnitOfWork _unitOfWork = scope.ServiceProvider.GetService<IUnitOfWork>();
                    IDomainEventRepository _domainEventRepository = scope.ServiceProvider.GetService<IDomainEventRepository>();
                    
                    await ProcessEvent(@event, _logger, _unitOfWork, _domainEventConsumer, _domainEventRepository);

                }, snapshot);
            }
        }

        private async Task ProcessEvent(IDomainEvent domainEvent, 
            ILogger<InMemoryEventBus> _logger, 
            IUnitOfWork _unitOfWork, 
            IDomainEventConsumer _domainEventConsumer,
            IDomainEventRepository _domainEventRepository)
        {
            var domainEventDb = await _domainEventRepository.GetAll()
                                                            .FirstOrDefaultAsync(de => de.EventId == domainEvent.EventId);

            if (domainEventDb != null && domainEventDb.Status == DomainEventStatus.Processed)
                return;

            if (domainEventDb != null && domainEventDb.Status == DomainEventStatus.Created)
            {
                domainEventDb.Status = DomainEventStatus.Processing;
                await _unitOfWork.ExecuteAsTransactionAsync(async () =>
                {
                    _domainEventRepository.Update(domainEventDb);
                    await _unitOfWork.SaveChangesAsync();
                });
            }

            if (domainEventDb == null)
            {
                domainEventDb = new DomainEvent
                {
                    EventId = domainEvent.EventId,
                    Name = domainEvent.Name,
                    Status = DomainEventStatus.Processing,
                    OccurredOn = domainEvent.OccurredOn,
                    EntityId = domainEvent.EntityId,
                    Data = domainEvent.Data
                };
                await _unitOfWork.ExecuteAsTransactionAsync(async () =>
                {
                    await _domainEventRepository.AddAsync(domainEventDb);
                    await _unitOfWork.SaveChangesAsync();
                });

                //domainEvent.EventId = domainEventDb.EventId;
            }

            var response = await _domainEventConsumer.Consume(domainEvent);

            _logger.LogInformation($"Response string: {JsonConvert.SerializeObject(response)}");

            if (!response.Success)
            {

                domainEventDb.Status = DomainEventStatus.Failed;
                await _unitOfWork.ExecuteAsTransactionAsync(async () =>
                {
                    _domainEventRepository.Update(domainEventDb);
                    await _unitOfWork.SaveChangesAsync();
                });

                return;
            }

            domainEventDb.Status = DomainEventStatus.Processed;
            await _unitOfWork.ExecuteAsTransactionAsync(async () =>
            {
                _domainEventRepository.Update(domainEventDb);
                await _unitOfWork.SaveChangesAsync();
            });
        }
    }

    public class WorkItem
    {
        public WorkItem(Func<CancellationToken, IServiceScope, ValueTask> action, SnapshotUserContext snapshotUserContext)
        {
            Action = action;
            SnapshotUserContext = snapshotUserContext;
        }

        public Func<CancellationToken, IServiceScope, ValueTask> Action { get; }

       public SnapshotUserContext SnapshotUserContext { get; }
}

    public sealed class BackgroundQueue
    {
        private readonly Channel<WorkItem> queue;

        public BackgroundQueue(int capacity)
        {
            BoundedChannelOptions options = new(capacity)
            {
                FullMode = BoundedChannelFullMode.Wait
            };
            queue = Channel.CreateBounded<WorkItem>(options);
        }

        /// <inheritdoc/>
        public async ValueTask EnqueueAsync(
            Func<CancellationToken, IServiceScope, ValueTask> action,
            SnapshotUserContext snapshotUserContext)
        {
            ArgumentNullException.ThrowIfNull(action, nameof(action));

            await queue.Writer.WriteAsync(new WorkItem(action, snapshotUserContext));
        }

        /// <inheritdoc/>
        public async ValueTask<WorkItem> DequeueAsync(
            CancellationToken cancellationToken)
        {
            WorkItem workItem = await queue.Reader.ReadAsync(cancellationToken);

            return workItem;
        }
    }

    public sealed class BackgroundQueueHostedService : BackgroundService
    {
        private readonly ILogger<BackgroundQueueHostedService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly BackgroundQueue _taskQueue;

        public BackgroundQueueHostedService(
            ILogger<BackgroundQueueHostedService> logger,
            IServiceScopeFactory serviceScopeFactory,
            BackgroundQueue taskQueue)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
            _taskQueue = taskQueue;

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                $"{nameof(BackgroundQueueHostedService)} started.{Environment.NewLine}");

            return ProcessTaskQueueAsync(stoppingToken);
        }

        /// <summary>
        /// Dequeues tasks from the queue and executes them.
        /// </summary>
        private async Task ProcessTaskQueueAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    WorkItem workItem =
                        await _taskQueue.DequeueAsync(stoppingToken);

                    if (workItem is not null && workItem.Action is not null)
                    {
                        using IServiceScope scope = _serviceScopeFactory.CreateScope();

                        OperationScope operationScope = scope.ServiceProvider.GetRequiredService<OperationScope>();
                        operationScope.Current = OperationScopeType.Background;
                        var snapshotUserContext = scope.ServiceProvider.GetRequiredService<SnapshotUserContext>();
                        snapshotUserContext.Initialize(workItem.SnapshotUserContext);

                        await workItem.Action(stoppingToken, scope);
                    }
                }
                catch (OperationCanceledException)
                {
                    // Prevent throwing if stoppingToken was signaled
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error occurred executing task work item in {nameof(BackgroundQueueHostedService)}.");
                }

                await Task.Delay(500);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                $"{nameof(BackgroundQueueHostedService)} is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}
