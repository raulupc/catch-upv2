using ssi730ebu202319415.API.Shared.Domain.Repositories;
using ssi730ebu202319415.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace ssi730ebu202319415.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync() => await context.SaveChangesAsync();
}