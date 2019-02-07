using CQRS.Prototype.Country.Domain.Interfaces;
using CQRS_Prototype.Domain.Core.Interfaces;

namespace CQRS.Prototype.Country.Persistence.EntityFramework
{
    public class CountryUow : IUnitOfWork
    {
        readonly ICountryService _countryService;
        public CountryUow(ICountryService service)
        {
            _countryService = service;
        }

        public IActionResponse<int> Commit()
        {
            return _countryService.CommitChanges();
        }

        public void Dispose()
        {
            
        }
    }
}
