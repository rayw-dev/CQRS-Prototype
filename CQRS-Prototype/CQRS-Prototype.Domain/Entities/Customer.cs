using CQRS_Prototype.Domain.Core.Models;
using CQRS_Prototype.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace CQRS_Prototype.Domain.Entities
{
    public class Customer : Entity<long>, ICustomer
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public long BillingAddressId { get; set; }
        public Address BillingAddress { get; set; }
        public IEnumerable<Address> BillingAddressHistory { get; set; }
        public IEnumerable<Address> ShippingAddresses { get; set; }
    }
}
