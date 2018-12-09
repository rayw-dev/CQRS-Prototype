using CQRS.Prototype.Country.Domain.Interfaces;
using CQRS_Prototype.Domain.Core.Interfaces;
using CQRS_Prototype.Domain.Interfaces;
using CQRS_Prototype.Domain.Models;
using System;
using System.Threading.Tasks;

namespace CQRS.Prototype.Country.Persistence.EntityFramework
{
    public class EntityFrameworkCountryService : ICountryService
    {
        readonly CountryContext _context;
        public EntityFrameworkCountryService(CountryContext context)
        {
            _context = context;
        }

        public Task<IActionResponse<Domain.Models.Country>> Create(Domain.Models.Country entity)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResponse<Domain.Models.Country>> Delete(Domain.Models.Country entity)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResponse<Domain.Models.Country>> FetchByAlpha2Code(string code)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResponse<Domain.Models.Country>> FetchByAlpha3Code(string code)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResponse<Domain.Models.Country>> FetchByEnglishName(string country)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResponse<Domain.Models.Country>> FetchByLocalName(string country)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResponse<Domain.Models.Country>> FetchByNumericCode(int code)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResponse<PagedResult<Domain.Models.Country>>> FetchList(ICountryListQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResponse<Domain.Models.Country>> FetchSingle(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataTransferImportResponse<Domain.Models.Country>> Import(IDataTransferImport<Domain.Models.Country> import)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResponse<Domain.Models.Country>> Update(Domain.Models.Country entity)
        {
            throw new NotImplementedException();
        }
    }
}
