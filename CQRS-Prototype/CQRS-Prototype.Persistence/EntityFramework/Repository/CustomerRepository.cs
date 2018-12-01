using CQRS_Prototype.Domain.Entities;
using CQRS_Prototype.Domain.Interfaces;

namespace CQRS_Prototype.Persistence.EntityFramework.Repository
{
    public class CustomerRepository : EntityFrameworkRepository<CustomerContext, Customer, long>, ICustomerRepository
    {
        public CustomerRepository(CustomerContext context) : base(context)
        {
        }
    }
}
