﻿using System;
using System.Collections.Generic;

namespace CQRS_Prototype.Domain.Interfaces
{
    public interface ICustomer<A, AH, C, SA> where A : IAddress<C> where C : ICountry where AH : ICustomerAddressHistory where SA: ICustomerShippingAddress
    {
        long Id { get; set; }
        string FirstName { get; set; }
        string Surname { get; set; }
        long BillingAddressId { get; set; }
        A BillingAddress { get; set; }
        IEnumerable<AH> BillingAddressHistory { get; set; }
        IEnumerable<SA> ShippingAddresses { get; set; }
    }

    public interface ICustomerAddressHistory
    {
        long CustomerId { get; set; }
        long AddressId { get; set; }
        DateTime EffectiveFrom { get; set; }
        DateTime? EffectiveTo { get; set; }
    }

    public interface ICustomerShippingAddress
    {
        long CustomerId { get; set; }
        long AddressId { get; set; }
    }
}
