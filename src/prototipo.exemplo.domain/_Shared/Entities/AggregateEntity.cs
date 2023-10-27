using Prototipo.Exemplo.Domain._Shared.Events;

namespace Prototipo.Exemplo.Domain._Shared.Entities;

/// <summary>
/// Classe abstrata que representa uma entidade agregada no domínio.
/// </summary>
/// <typeparam name="TEntityId">O tipo do identificador da entidade.</typeparam>
public abstract class AggregateEntity<TEntityId> : Entity<TEntityId>, IGeneratesDomainEvents
    where TEntityId : EntityId
{
    /// <summary>
    /// Lista de eventos de domínio associados a esta entidade agregada.
    /// </summary>
    private readonly List<DomainEvent> _domainEvents = new List<DomainEvent>();

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Entity{TKey}"/>.
    /// </summary>
    protected AggregateEntity()
        : base() { }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Entity{TKey}"/> com um identificador.
    /// </summary>
    /// <param name="id">O identificador da entidade.</param>
    protected AggregateEntity(TEntityId id)
        : base(id) { }

    /// <summary>
    /// Obtém a lista somente leitura de eventos de domínio associados a esta entidade agregada.
    /// </summary>
    protected IReadOnlyList<DomainEvent> DomainEvents
        => _domainEvents.AsReadOnly();

    /// <summary>
    /// Limpa a lista de eventos de domínio associados a esta entidade agregada.
    /// </summary>
    public virtual void ClearEvents()
        => _domainEvents.Clear();

    /// <summary>
    /// Registra um novo evento de domínio associado a esta entidade agregada.
    /// </summary>
    /// <param name="eventNotification">O evento de notificação do evento.</param>
    protected virtual void RegisterEvent(EventNotification eventNotification)
        => _domainEvents.Add(DomainEvent.Create(this, eventNotification));

    /// <summary>
    /// Obtém todos os eventos de domínio associados a esta entidade agregada.
    /// </summary>
    /// <returns>Uma coleção de eventos de domínio.</returns>
    public IEnumerable<DomainEvent> GetEvents()
        => _domainEvents.AsEnumerable();
}
