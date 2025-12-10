namespace ssi730ebu202319415.API.Observability.Domain.Model.ValueObjects;

public record ThingSerialNumber(Guid Value = default)
{
    public ThingSerialNumber() : this(Guid.Empty) { }
}