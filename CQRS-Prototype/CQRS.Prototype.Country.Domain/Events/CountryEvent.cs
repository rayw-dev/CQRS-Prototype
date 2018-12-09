using CQRS.Prototype.Country.Domain.Extensions;
using CQRS.Prototype.Country.Domain.Interfaces;
using CQRS_Prototype.Domain.Core.Events;
using System;

namespace CQRS.Prototype.Country.Domain.Events
{
    public abstract class CountryEvent : Event<Guid>, ICountry
    {
        public long Id { get; set; }
        public string EnglishName { get; set; }
        public string LocalName { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public int NumericCode { get; set; }
        public bool Independant { get; set; }

        public CountryEvent() : base()
        {

        }

        public CountryEvent(ICountry country) : this()
        {
            this.Merge(country);
        }
    }
}
