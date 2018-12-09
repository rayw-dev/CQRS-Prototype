namespace CQRS.Prototype.Country.Domain.Interfaces
{
    public interface ICountry
    {
        long Id { get; set; }
        string EnglishName { get; set; }
        string LocalName { get; set; }
        string Alpha2Code { get; set; }
        string Alpha3Code { get; set; }
        int NumericCode { get; set; }
        bool Independant { get; set; }
    }
}
