using ssi730ebu202319415.API.Observability.Domain.Model.Aggregates;
using ssi730ebu202319415.API.Observability.Domain.Model.ValueObjects;
using ssi730ebu202319415.API.Shared.Domain.Repositories;

namespace ssi730ebu202319415.API.Observability.Domain.Repositories;

public interface IThingStateRepository : IBaseRepository<ThingState>
{
    Task<ThingState?> FindByThingSerialNumberAndCollectedAtAsync(ThingSerialNumber serialNumber, DateTime collectedAt);
}