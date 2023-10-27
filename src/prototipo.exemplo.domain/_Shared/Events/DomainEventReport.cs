namespace Prototipo.Exemplo.Domain._Shared.Events;

public class DomainEventReport
{
    public List<DomainEvent> Events { get; }

    public DomainEventReport()
    {
        Events = new List<DomainEvent>();
    }

    public override string ToString()
    {
        return $"[{nameof(DomainEventReport)}] DomainEvents: {Events.Count} ";
    }
}

