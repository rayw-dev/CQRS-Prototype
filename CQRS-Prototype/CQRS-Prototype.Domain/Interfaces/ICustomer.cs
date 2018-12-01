using CQRS_Prototype.Domain.Core.Interfaces;
using CQRS_Prototype.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CQRS_Prototype.Domain.Interfaces
{
    public interface ICustomer : IEntity<long>
    {
        string FirstName { get; set; }
        string Surname { get; set; }
        long BillingAddressId { get; set; }
        Address BillingAddress { get; set; }
        IEnumerable<Address> BillingAddressHistory { get; set; }
        IEnumerable<Address> ShippingAddresses { get; set; }
    }
}
