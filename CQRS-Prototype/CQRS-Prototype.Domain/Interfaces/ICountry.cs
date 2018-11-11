namespace CQRS_Prototype.Domain.Interfaces
{
    public interface ICountry
    {
        long Id { get; set; }
        string CountryName { get; set; }
        string CountryCode { get; set; }
    }
}
