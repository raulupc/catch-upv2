using ssi730ebu202319415.API.Inventory.Domain.Model.Enumerations;

namespace ssi730ebu202319415.API.Observability.Domain.Services;

public interface IInventoryAcl
{
    Task<bool> ExistsThingAsync(Guid serialNumber);
    Task UpdateOperationModeAsync(Guid serialNumber, EOperationMode mode);
}