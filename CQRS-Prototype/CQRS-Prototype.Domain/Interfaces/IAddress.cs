using CQRS_Prototype.Domain.Core.Interfaces;
using CQRS_Prototype.Domain.Entities;

namespace CQRS_Prototype.Domain.Interfaces
{
    public interface IAddress : IEntity<long>
    {
        string FirstLine { get; set; }
        string SecondLine { get; set; }
        string ThirdLine { get; set; }
        string FourthLine { get; set; }
        string City { get; set; }
        long CountryId { get; set; }
        Country Country { get; set; }
        string PostalCode { get; set; }
        string Latitude { get; set; }
        string Longitude { get; set; }
    }
}
