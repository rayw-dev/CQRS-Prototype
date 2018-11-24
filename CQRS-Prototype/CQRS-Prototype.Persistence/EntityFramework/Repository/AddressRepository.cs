using CQRS_Prototype.Domain.Entities;
using CQRS_Prototype.Domain.Interfaces;

namespace CQRS_Prototype.Persistence.EntityFramework.Repository
{
    public class AddressRepository : EntityFrameworkRepository<CustomerContext, Address, long>, IAddressRepository<Address, Country, long>
    {
        public AddressRepository(CustomerContext context) : base(context)
        {
        }
    }
}
