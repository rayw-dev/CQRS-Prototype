using CQRS_Prototype.Domain.Entities;

namespace CQRS_Prototype.Domain.Interfaces
{
    public interface ICountryRepository : IRepository<Country, long>
    {
    }
}
