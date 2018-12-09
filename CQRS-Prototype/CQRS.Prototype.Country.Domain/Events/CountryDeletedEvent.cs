using CQRS.Prototype.Country.Domain.Interfaces;
using CQRS_Prototype.Domain.Core.Events;

namespace CQRS.Prototype.Country.Domain.Events
{
    public class CountryDeletedEvent : CountryEvent
    {
        public CountryDeletedEvent() : base()
        {
            EventType = EventType.ResourceDeleted;
        }

        public CountryDeletedEvent(ICountry country) : base(country)
        {
            EventType = EventType.ResourceDeleted;
        }
    }
}
