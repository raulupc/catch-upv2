using Microsoft.EntityFrameworkCore;
using ssi730ebu202319415.API.Shared.Domain.Repositories;
using ssi730ebu202319415.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace ssi730ebu202319415.API.Shared.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Base repository implementation with correct async signatures
/// </summary>
/// <remarks>
/// Author: Raul Hiroshi Tasayco Osorio
/// </remarks>
public abstract class BaseRepository<TEntity>(AppDbContext context) : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext Context = context;

    public async Task AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
        // No necesitamos Task.Run porque AddAsync ya es async
    }

    public void Update(TEntity entity)
        => Context.Set<TEntity>().Update(entity);

    public void Remove(TEntity entity)
        => Context.Set<TEntity>().Remove(entity);

    public async Task<TEntity?> FindByIdAsync(int id)
        => await Context.Set<TEntity>().FindAsync(id);

    public async Task<IEnumerable<TEntity>> ListAsync()
        => await Context.Set<TEntity>().ToListAsync();
    // ToListAsync() devuelve Task<List<TEntity>> que se convierte automáticamente a Task<IEnumerable<TEntity>>
}