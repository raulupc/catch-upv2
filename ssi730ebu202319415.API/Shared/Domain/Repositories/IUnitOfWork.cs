namespace ssi730ebu202319415.API.Shared.Domain.Repositories;

/// <summary>
/// Unit of work interface.
/// </summary>
/// <remarks>
/// Author: Raul Hiroshi Tasayco Osorio
/// </remarks>
public interface IUnitOfWork
{
    Task CompleteAsync();
}