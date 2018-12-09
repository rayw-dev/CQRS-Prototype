using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Prototype.Country.Domain.Events
{
    public class CountryEventHandler :
        INotificationHandler<CountryCreatedEvent>,
        INotificationHandler<CountryUpdatedEvent>,
        INotificationHandler<CountryDeletedEvent>
    {
        public Task Handle(CountryCreatedEvent notification, CancellationToken cancellationToken)
        {
            //Audit
            //Log
            return Task.CompletedTask;
        }
        public Task Handle(CountryUpdatedEvent notification, CancellationToken cancellationToken)
        {
            //Audit
            //Log
            return Task.CompletedTask;
        }

        public Task Handle(CountryDeletedEvent notification, CancellationToken cancellationToken)
        {
            //Audit
            //Log
            return Task.CompletedTask;
        }
    }
}
