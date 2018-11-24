using CQRS_Prototype.Domain.Core.Models;
using CQRS_Prototype.Domain.Interfaces;

namespace CQRS_Prototype.Domain.Entities
{
    public class Country : Entity<long>, ICountry<long>
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
    }
}
