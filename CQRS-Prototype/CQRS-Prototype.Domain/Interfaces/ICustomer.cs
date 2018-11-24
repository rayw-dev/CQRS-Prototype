using CQRS_Prototype.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace CQRS_Prototype.Domain.Interfaces
{
    public interface ICustomer<A, AH, C, SA, TKey> : IEntity<TKey> where A : IAddress<C, TKey> where C : ICountry<TKey> where AH : ICustomerAddressHistory<TKey> where SA : ICustomerShippingAddress<TKey>
    {
        string FirstName { get; set; }
        string Surname { get; set; }
        long BillingAddressId { get; set; }
        A BillingAddress { get; set; }
        IEnumerable<AH> BillingAddressHistory { get; set; }
        IEnumerable<SA> ShippingAddresses { get; set; }
    }

    public interface ICustomerAddressHistory<TKey>
    {
        TKey CustomerId { get; set; }
        TKey AddressId { get; set; }
        DateTime EffectiveFrom { get; set; }
        DateTime? EffectiveTo { get; set; }
    }

    public interface ICustomerShippingAddress<TKey>
    {
        TKey CustomerId { get; set; }
        TKey AddressId { get; set; }
    }
}
