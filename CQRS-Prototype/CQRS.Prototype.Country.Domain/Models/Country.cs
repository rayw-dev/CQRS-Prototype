namespace CQRS.Prototype.Country.Domain.Models
{
    public class Country : Interfaces.ICountry
    {
        public string EnglishName { get; set; }
        public string LocalName { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public int NumericCode { get; set; }
        public bool Independant { get; set; }
    }
}
