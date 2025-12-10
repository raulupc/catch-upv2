using Microsoft.EntityFrameworkCore;
using ssi730ebu202319415.API.Observability.Domain.Model.Aggregates;
using ssi730ebu202319415.API.Observability.Domain.Model.ValueObjects;
using ssi730ebu202319415.API.Observability.Domain.Repositories;
using ssi730ebu202319415.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ssi730ebu202319415.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ssi730ebu202319415.API.Observability.Infrastructure.Persistence.EFC.Repositories;

public class ThingStateRepository(AppDbContext context) : BaseRepository<ThingState>(context), IThingStateRepository
{
    public async Task<ThingState?> FindByThingSerialNumberAndCollectedAtAsync(ThingSerialNumber serialNumber, DateTime collectedAt)
        => await Context.Set<ThingState>()
            .FirstOrDefaultAsync(ts => ts.ThingSerialNumber.Value == serialNumber.Value && ts.CollectedAt == collectedAt);
}