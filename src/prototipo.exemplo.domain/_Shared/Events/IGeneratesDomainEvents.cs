namespace Prototipo.Exemplo.Domain._Shared.Events;

/// <summary>
/// Representa uma interface para geração de eventos de domínio.
/// </summary>
public interface IGeneratesDomainEvents
{
    /// <summary>
    /// Obtém a coleção de registros de eventos de domínio.
    /// </summary>
    /// <returns>Uma coleção enumerável de objetos DomainEventRecord.</returns>
    IEnumerable<DomainEvent> GetEvents();

    /// <summary>
    /// Limpa a coleção de registros de eventos de domínio.
    /// </summary>
    void ClearEvents();
}
