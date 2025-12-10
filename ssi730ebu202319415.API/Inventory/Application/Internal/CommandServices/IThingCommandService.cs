using ssi730ebu202319415.API.Inventory.Domain.Model.Aggregates;
using ssi730ebu202319415.API.Inventory.Domain.Model.Commands;

namespace ssi730ebu202319415.API.Inventory.Application.Internal.CommandServices;

public interface IThingCommandService
{
    Task<Thing?> Handle(CreateThingCommand command);
}