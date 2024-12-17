using Levara.DAL.DbContext;
using Levara.Domain.DAL;
using Levara.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Levara.DAL;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;
    private readonly IServiceProvider _serviceProvider;
    private bool _disposed = false;

    public UnitOfWork(ApplicationDbContext context,
        IServiceProvider serviceProvider)
    {
        _context = context;
        _serviceProvider = serviceProvider;
    }

    public IRepository<TEntity> Repository<TEntity>() where TEntity : Entity
    {
        return _serviceProvider.GetRequiredService<IRepository<TEntity>>();
    }

    public ApplicationDbContext Context { get { return _context; } }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task ExecuteAsTransactionAsync(Func<Task> asyncLogic)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            await asyncLogic();
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();

            throw ex;
        }
    }
    public async Task<T> ExecuteAsTransactionAsync<T>(Func<Task<T>> asyncLogic)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            // Ejecuta la lógica personalizada
            T result = await asyncLogic();

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return result;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw; // Mantén la excepción original
        }
    }


    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
            _context.Dispose();

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~UnitOfWork()
    {
        Dispose(false);
    }
}
