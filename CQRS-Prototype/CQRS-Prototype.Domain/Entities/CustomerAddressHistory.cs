using CQRS_Prototype.Domain.Interfaces;
using System;

namespace CQRS_Prototype.Domain.Entities
{
    public class CustomerAddressHistory : ICustomerAddressHistory<long>
    {
        public long CustomerId { get; set; }
        public long AddressId { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public Address Address { get; set; }
    }
}
