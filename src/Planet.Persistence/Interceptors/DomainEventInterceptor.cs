using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Planet.Domain.SharedKernel;

namespace Planet.Persistence.Interceptors
{
    public class DomainEventInterceptor : SaveChangesInterceptor
    {
        private readonly IPublisher _publisher;

        public DomainEventInterceptor(IPublisher publisher)
        {
            _publisher = publisher;
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var domainEvents = eventData.Context.ChangeTracker.Entries()
                .Where(e => e.Entity is Entity)
                .Select(e => e.Entity as Entity)
                .SelectMany(e => e.DomainEvents);

            foreach(var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent);
            }

            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
