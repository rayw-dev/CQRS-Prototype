using CQRS_Prototype.Domain.Interfaces;

namespace CQRS_Prototype.Domain.Entities
{
    public class CustomerShippingAddress : ICustomerShippingAddress<long>
    {
        public long CustomerId { get; set; }
        public long AddressId { get; set; }
        public Address Address { get; set; }
    }
}
