using CQRS_Prototype.Domain.Entities;

namespace CQRS_Prototype.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer, long>
    {
    }
}
