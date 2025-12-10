namespace ssi730ebu202319415.API.Inventory.Domain.Model.ValueObjects;

public record SerialNumber(Guid Value = default)
{
    public SerialNumber() : this(Guid.NewGuid()) { }
}