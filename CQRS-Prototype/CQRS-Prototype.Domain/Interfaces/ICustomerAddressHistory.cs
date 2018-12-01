using CQRS_Prototype.Domain.Entities;
using System;

namespace CQRS_Prototype.Domain.Interfaces
{
    public interface ICustomerAddressHistory<TKey>
    {
        TKey CustomerId { get; set; }
        TKey AddressId { get; set; }
        Address Address { get; set; }
        DateTime EffectiveFrom { get; set; }
        DateTime? EffectiveTo { get; set; }
    }
}
