using CQRS_Prototype.Domain.Entities;

namespace CQRS_Prototype.Domain.Interfaces
{
    public interface ICustomerShippingAddress<TKey>
    {
        TKey CustomerId { get; set; }
        TKey AddressId { get; set; }
        Address Address { get; set; }
    }
}
