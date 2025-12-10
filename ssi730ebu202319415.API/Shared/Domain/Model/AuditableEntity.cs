namespace ssi730ebu202319415.API.Shared.Domain.Model;

/// <summary>
/// Base entity with audit fields
/// </summary>
/// <remarks>
/// Author: Raul Hiroshi Tasayco Osorio
/// </remarks>
public abstract class AuditableEntity<TKey>
{
    public TKey Id { get; protected set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}