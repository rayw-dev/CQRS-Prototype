using CQRS_Prototype.Domain.Entities;
using CQRS_Prototype.Domain.Interfaces;

namespace CQRS_Prototype.Persistence.EntityFramework.Repository
{
    public class CountryRepository : EntityFrameworkRepository<CustomerContext, Country, long>, ICountryRepository
    {
        public CountryRepository(CustomerContext context) : base(context)
        {

        }
    }
}
