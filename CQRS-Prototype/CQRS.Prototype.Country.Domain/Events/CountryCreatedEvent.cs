using CQRS.Prototype.Country.Domain.Interfaces;
using CQRS_Prototype.Domain.Core.Events;

namespace CQRS.Prototype.Country.Domain.Events
{
    public class CountryCreatedEvent : CountryEvent
    {
        public CountryCreatedEvent() : base()
        {
            EventType = EventType.ResourceCreated;
        }

        public CountryCreatedEvent(ICountry country) : base(country)
        {
            EventType = EventType.ResourceCreated;
        }
    }
}
