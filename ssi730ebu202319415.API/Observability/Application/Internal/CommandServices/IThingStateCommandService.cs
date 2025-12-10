using ssi730ebu202319415.API.Observability.Domain.Model.Aggregates;
using ssi730ebu202319415.API.Observability.Domain.Model.Commands;

namespace ssi730ebu202319415.API.Observability.Application.Internal.CommandServices;

public interface IThingStateCommandService
{
    Task<ThingState?> Handle(CreateThingStateCommand command);
}