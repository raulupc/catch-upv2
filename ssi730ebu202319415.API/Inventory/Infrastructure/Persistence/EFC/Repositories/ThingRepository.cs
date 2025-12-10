using Microsoft.EntityFrameworkCore;
using ssi730ebu202319415.API.Inventory.Domain.Model.Aggregates;
using ssi730ebu202319415.API.Inventory.Domain.Model.ValueObjects;
using ssi730ebu202319415.API.Inventory.Domain.Repositories;
using ssi730ebu202319415.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ssi730ebu202319415.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ssi730ebu202319415.API.Inventory.Infrastructure.Persistence.EFC.Repositories;

public class ThingRepository(AppDbContext context) : BaseRepository<Thing>(context), IThingRepository
{
    public async Task<Thing?> FindBySerialNumberAsync(SerialNumber serialNumber)
        => await Context.Set<Thing>().FirstOrDefaultAsync(t => t.SerialNumber.Value == serialNumber.Value);
}