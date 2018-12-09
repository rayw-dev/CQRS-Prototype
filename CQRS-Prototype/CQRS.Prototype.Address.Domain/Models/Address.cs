using CQRS.Prototype.Address.Domain.Interfaces;

namespace CQRS.Prototype.Address.Domain.Models
{
    public class Address : IAddress
    {
        public long Id { get; set; }
        public string FirstLine { get; set; }
        public string SecondLine { get; set; }
        public string ThirdLine { get; set; }
        public string FourthLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
