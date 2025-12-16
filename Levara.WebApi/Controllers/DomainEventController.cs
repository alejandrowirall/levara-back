using Levara.Domain.Authentication;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Events;

using Levara.Shared.Domain.Bus.Events;
using Levara.Shared.Infrastructure.Bus.Events;
using Levara.WebApi.Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json;

namespace Levara.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeAnyRoles(Roles.Admin)]
    public class DomainEventController : ControllerBase
    {
        private readonly DomainEventJsonDeserializer _domainEventJsonDeserializer;
        private readonly IDomainEventConsumer _domainEventConsumer;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainEventRepository _domainEventRepository;
        private readonly ILogger<DomainEventController> _logger;
        public DomainEventController(DomainEventJsonDeserializer domainEventJsonDeserializer,
            IDomainEventConsumer domainEventConsumer,
            IUnitOfWork unitOfWork,
            IDomainEventRepository domainEventRepository,
            ILogger<DomainEventController> logger)
        {
            _domainEventJsonDeserializer = domainEventJsonDeserializer;
            _domainEventConsumer = domainEventConsumer;
            _unitOfWork = unitOfWork;
            _domainEventRepository = domainEventRepository;
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> Process([FromBody] EventRequest request)
        {
            _logger.LogInformation($"Request string: {JsonConvert.SerializeObject(request)}");
            _logger.LogInformation($"Request Detail string: {request.Detail.GetRawText()}");

            var domainEvent = _domainEventJsonDeserializer.Deserialize(request.Detail.GetRawText());

            if (domainEvent.IsJob())
                return await ProcessJob(domainEvent);

            var domainEventDb = await _domainEventRepository.GetAll()
                                                            .FirstOrDefaultAsync(de => de.EventId == domainEvent.EventId);

            if (domainEventDb == null)
                return NotFound();

            if (domainEventDb.Status == DomainEventStatus.Processed)
                return Ok();

            if (domainEventDb.Status == DomainEventStatus.Created)
            {
                domainEventDb.Status = DomainEventStatus.Processing;
                _domainEventRepository.Update(domainEventDb);
                await _unitOfWork.SaveChangesAsync();
            }

            var response = await _domainEventConsumer.Consume(domainEvent);

            _logger.LogInformation($"Response string: {JsonConvert.SerializeObject(response)}");

            if (!response.Success)
            {
                _logger.LogError($"Response string: {response.Error?.Message}");
                domainEventDb.Status = DomainEventStatus.Failed;
                _domainEventRepository.Update(domainEventDb);
                await _unitOfWork.SaveChangesAsync();

                return new ObjectResult(response)
                {
                    StatusCode = response.Error!.StatusCode
                };
            }
            
            domainEventDb.Status = DomainEventStatus.Processed;
            _domainEventRepository.Update(domainEventDb);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        private async Task<IActionResult> ProcessJob(IDomainEvent domainEvent)
        {

            var response = await _domainEventConsumer.Consume(domainEvent);

            _logger.LogInformation($"Response string: {JsonConvert.SerializeObject(response)}");

            if (!response.Success)
            {
                return new ObjectResult(response)
                {
                    StatusCode = response.Error!.StatusCode
                };
            }

            return Ok();
        }
    }
}

public class EventRequest
{
    public string Version { get; set; }
    public string Id { get; set; }
    
    //public string DetailType { get; set; }
    public string Source { get; set; }
    public string Account { get; set; }
    public DateTime Time { get; set; }
    public string Region { get; set; }
    public List<string> Resources { get; set; }
    public JsonElement Detail { get; set; }
}
