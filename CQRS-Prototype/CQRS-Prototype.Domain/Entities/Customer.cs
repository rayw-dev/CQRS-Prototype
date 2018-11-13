using CQRS_Prototype.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace CQRS_Prototype.Domain.Entities
{
    public class Customer : ICustomer<Address, CustomerAddressHistory, Country, CustomerShippingAddress>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public long BillingAddressId { get; set; }
        public Address BillingAddress { get; set; }
        public IEnumerable<CustomerAddressHistory> BillingAddressHistory { get; set; }
        public IEnumerable<CustomerShippingAddress> ShippingAddresses { get; set; }
    }

    public class CustomerAddressHistory : ICustomerAddressHistory
    {
        public long CustomerId { get; set; }
        public long AddressId { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }

    public class CustomerShippingAddress : ICustomerShippingAddress
    {
        public long CustomerId { get; set; }
        public long AddressId { get; set; }
    }
}
