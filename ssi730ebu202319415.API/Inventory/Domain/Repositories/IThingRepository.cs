using ssi730ebu202319415.API.Inventory.Domain.Model.Aggregates;
using ssi730ebu202319415.API.Inventory.Domain.Model.ValueObjects;
using ssi730ebu202319415.API.Shared.Domain.Repositories;

namespace ssi730ebu202319415.API.Inventory.Domain.Repositories;

public interface IThingRepository : IBaseRepository<Thing>
{
    Task<Thing?> FindBySerialNumberAsync(SerialNumber serialNumber);
}