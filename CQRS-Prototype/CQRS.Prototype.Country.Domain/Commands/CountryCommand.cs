using CQRS.Prototype.Country.Domain.Extensions;
using CQRS.Prototype.Country.Domain.Interfaces;
using CQRS_Prototype.Domain.Core.Commands;

namespace CQRS.Prototype.Country.Domain.Commands
{
    public abstract class CountryCommand : Command, ICountry
    {
        public long Id { get; set; }
        public string EnglishName { get; set; }
        public string LocalName { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public int NumericCode { get; set; }
        public bool Independant { get; set; }

        public CountryCommand(ICountry country)
        {
            this.Merge(country);
        }
    }
}
