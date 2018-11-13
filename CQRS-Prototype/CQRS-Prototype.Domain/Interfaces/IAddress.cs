using System;

namespace CQRS_Prototype.Domain.Interfaces
{
    public interface IAddress<C> where C : ICountry
    {
        long Id { get; set; }
        string FirstLine { get; set; }
        string SecondLine { get; set; }
        string ThirdLine { get; set; }
        string FourthLine { get; set; }
        string City { get; set; }
        long CountryId { get; set; }
        C Country { get; set; }
        string PostalCode { get; set; }
        string Latitude { get; set; }
        string Longitude { get; set; }
    }
}
