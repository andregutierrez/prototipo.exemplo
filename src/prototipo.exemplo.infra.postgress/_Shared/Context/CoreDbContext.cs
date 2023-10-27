using MediatR;
using Microsoft.EntityFrameworkCore;
using Prototipo.Exemplo.Domain._Shared.Events;

namespace Prototipo.Exemplo.Infra.Postgress._Shared.Context;

public abstract class CoreDbContext : DbContext
{
    private IMediator _mediator;

    public CoreDbContext(DbContextOptions options, IMediator mediator)
        : base(options) => _mediator = mediator;


    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

            var eventReport = CreateEventReport();
            PublishEntityEvents(eventReport);

            return result;
        }

        finally
        {
            ChangeTracker.AutoDetectChangesEnabled = true;
        }
    }

    private void PublishEntityEvents(DomainEventReport changeReport)
    {
        var localEvents = changeReport
            .Events
            .OrderBy(o => o.Order);

        foreach (var localEvent in localEvents)
        {
            _mediator.Publish(localEvent.EventNotification);
        }
    }

    protected virtual DomainEventReport CreateEventReport()
    {
        var eventReport = new DomainEventReport();

        foreach (var entry in ChangeTracker.Entries().ToList())
        {
            var generatesDomainEventsEntity = entry.Entity as IGeneratesDomainEvents;
            if (generatesDomainEventsEntity == null)
            {
                continue;
            }

            var domainEvents = generatesDomainEventsEntity.GetEvents()?.ToArray();
            if (domainEvents != null && domainEvents.Any())
            {
                eventReport.Events.AddRange(domainEvents.ToList());
                generatesDomainEventsEntity.ClearEvents();
            }
        }

        return eventReport;
    }
}