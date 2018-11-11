using CQRS_Prototype.Domain.Interfaces;

namespace CQRS_Prototype.Domain.Entities
{
    public class Country : ICountry
    {
        public long Id { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
    }
}
