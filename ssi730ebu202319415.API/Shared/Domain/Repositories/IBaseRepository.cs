// Shared/Domain/Repositories/IBaseRepository.cs
namespace ssi730ebu202319415.API.Shared.Domain.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task<TEntity?> FindByIdAsync(int id);
    Task<IEnumerable<TEntity>> ListAsync();  // <-- IEnumerable<TEntity>, no ICollection
}