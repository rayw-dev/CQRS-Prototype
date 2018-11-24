using CQRS_Prototype.Domain.Core.Interfaces;

namespace CQRS_Prototype.Domain.Interfaces
{
    public interface IAddress<C, TKey> : IEntity<TKey> where C : ICountry<TKey>
    {
        string FirstLine { get; set; }
        string SecondLine { get; set; }
        string ThirdLine { get; set; }
        string FourthLine { get; set; }
        string City { get; set; }
        TKey CountryId { get; set; }
        C Country { get; set; }
        string PostalCode { get; set; }
        string Latitude { get; set; }
        string Longitude { get; set; }
    }
}
