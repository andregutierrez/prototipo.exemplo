namespace Prototipo.Exemplo.Domain._Shared.Events;

/// <summary>
/// Representa um evento de domínio que ocorreu no sistema.
/// </summary>
public class DomainEvent
{
    /// <summary>
    /// Obtém o evento de entidade associado a este evento de domínio.
    /// </summary>
    public EventNotification EventNotification { get; }

    /// <summary>
    /// Entidade relacionada ao evento
    /// </summary>
    /// <value></value>
    public object Entity { get; set; }

    /// <summary>
    /// Obtém a ordem do evento.
    /// </summary>
    public long Order { get; }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="DomainEvent"/>.
    /// </summary>
    /// <param name="eventNotification">O evento de entidade associado a este evento de domínio.</param>
    /// <param name="eventOrder">A ordem do evento.</param>
    public DomainEvent(object entity, EventNotification eventNotification, long eventOrder)
    {
        Entity = entity;
        EventNotification = eventNotification;
        Order = eventOrder;
    }

    /// <summary>
    /// Variável estática para armazenar o último número gerado.
    /// </summary>
    private static long _last;

    /// <summary>
    /// Cria um novo evento de domínio com o evento de entidade especificado e incrementa a ordem do evento.
    /// </summary>
    /// <param name="eventNotification">O evento de entidade associado ao evento de domínio.</param>
    /// <returns>Uma nova instância da classe <see cref="DomainEvent"/>.</returns>
    public static DomainEvent Create(object entity, EventNotification eventNotification)
    {
        _last = Interlocked.Increment(ref _last);
        return new DomainEvent(entity, eventNotification, _last);
    }
}

