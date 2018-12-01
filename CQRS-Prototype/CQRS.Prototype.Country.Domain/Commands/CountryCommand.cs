using CQRS.Prototype.Country.Domain.Interfaces;
using CQRS_Prototype.Domain.Core.Commands;

namespace CQRS.Prototype.Country.Domain.Commands
{
    public abstract class CountryCommand : Command, ICountry
    {
        public string EnglishName { get; set; }
        public string LocalName { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public int NumericCode { get; set; }
        public bool Independant { get; set; }

        public CountryCommand(ICountry country)
        {
            if (country is null) return;
            EnglishName = country.EnglishName;
            LocalName = country.LocalName;
            Alpha2Code = country.Alpha2Code;
            Alpha3Code = country.Alpha3Code;
            NumericCode = country.NumericCode;
            Independant = country.Independant;
        }
    }
}
