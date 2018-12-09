using CQRS.Prototype.Country.Domain.Interfaces;
using CQRS_Prototype.Domain.Core.Events;

namespace CQRS.Prototype.Country.Domain.Events
{
    public class CountryUpdatedEvent : CountryEvent
    {
        public CountryUpdatedEvent() : base()
        {
            EventType = EventType.ResourceUpdated;
        }

        public CountryUpdatedEvent(ICountry country) : base(country)
        {
            EventType = EventType.ResourceUpdated;
        }
    }
}
