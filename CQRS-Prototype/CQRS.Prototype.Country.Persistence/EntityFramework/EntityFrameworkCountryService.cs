using CQRS.Prototype.Country.Domain.Extensions;
using CQRS.Prototype.Country.Domain.Interfaces;
using CQRS_Prototype.Domain.Core.Interfaces;
using CQRS_Prototype.Domain.Core.Models;
using CQRS_Prototype.Domain.Extensions;
using CQRS_Prototype.Domain.Interfaces;
using CQRS_Prototype.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CQRS.Prototype.Country.Persistence.EntityFramework
{
    public class EntityFrameworkCountryService : ICountryService
    {
        readonly CountryContext _context;
        public EntityFrameworkCountryService(CountryContext context)
        {
            _context = context;
        }

        public IActionResponse<Domain.Models.Country> Delete(Domain.Models.Country entity)
        {
            var returnValue = new ActionResponse<Domain.Models.Country>
            {
                Success = true,
                Data = entity
            };
            var existing = _context.Countries.Where(c => (entity.Id > 0 && c.Id.Equals(entity.Id)) ||
                c.EnglishName.Equals(entity.EnglishName, StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault();
            if (existing?.Id > 0)
            {
                //Delete
                _context.Countries.Remove(existing);
                returnValue.Data = existing;
                return returnValue;
            }
            else
            {
                //Item not found or already deleted
                //return true with warning
                returnValue.WarningMessages.Add($"Country Not Found");
                return returnValue;
            }
        }

        public IActionResponse<Domain.Models.Country> FetchByAlpha2Code(string code)
        {
            var existing = _context.Countries.Where(c => c.Alpha2Code.Equals(code, StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault();
            if (existing?.Id > 0)
            {
                return new ActionResponse<Domain.Models.Country>
                {
                    Success = true,
                    Data = existing
                };
            }
            else
            {
                var returnValue = new ActionResponse<Domain.Models.Country>();
                returnValue.ErrorMessages.Add($"Country with Alpha 2 Code {code} not found");
                return returnValue;
            }
        }

        public IActionResponse<Domain.Models.Country> FetchByAlpha3Code(string code)
        {
            var existing = _context.Countries.Where(c => c.Alpha3Code.Equals(code, StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault();
            if (existing?.Id > 0)
            {
                return new ActionResponse<Domain.Models.Country>
                {
                    Success = true,
                    Data = existing
                };
            }
            else
            {
                var returnValue = new ActionResponse<Domain.Models.Country>();
                returnValue.ErrorMessages.Add($"Country with Alpha 3 Code {code} not found");
                return returnValue;
            }
        }

        public IActionResponse<Domain.Models.Country> FetchByEnglishName(string country)
        {
            var existing = _context.Countries.Where(c => c.EnglishName.Equals(country, StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault();
            if (existing?.Id > 0)
            {
                return new ActionResponse<Domain.Models.Country>
                {
                    Success = true,
                    Data = existing
                };
            }
            else
            {
                var returnValue = new ActionResponse<Domain.Models.Country>();
                returnValue.ErrorMessages.Add($"Country with English Name {country} not found");
                return returnValue;
            }
        }

        public IActionResponse<Domain.Models.Country> FetchByLocalName(string country)
        {
            var existing = _context.Countries.Where(c => c.LocalName.Equals(country, StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault();
            if (existing?.Id > 0)
            {
                return new ActionResponse<Domain.Models.Country>
                {
                    Success = true,
                    Data = existing
                };
            }
            else
            {
                var returnValue = new ActionResponse<Domain.Models.Country>();
                returnValue.ErrorMessages.Add($"Country with Local Name {country} not found");
                return returnValue;
            }
        }

        public IActionResponse<Domain.Models.Country> FetchByNumericCode(int code)
        {
            var existing = _context.Countries.Where(c => c.NumericCode.Equals(code)).SingleOrDefault();
            if (existing?.Id > 0)
            {
                return new ActionResponse<Domain.Models.Country>
                {
                    Success = true,
                    Data = existing
                };
            }
            else
            {
                var returnValue = new ActionResponse<Domain.Models.Country>();
                returnValue.ErrorMessages.Add($"Country with Numeric Code {code} not found");
                return returnValue;
            }
        }

        public IActionResponse<PagedResult<Domain.Models.Country>> FetchList(ICountryListQuery query)
        {
            var returnValue = new ActionResponse<PagedResult<Domain.Models.Country>>
            {
                Success = true
            };

            var countries = _context.Countries.Where(c =>
                (string.IsNullOrWhiteSpace(query.NameFilter) && EF.Functions.Like(c.EnglishName, $"%{query.NameFilter}%")) ||
                (string.IsNullOrWhiteSpace(query.NameFilter) && EF.Functions.Like(c.LocalName, $"%{query.NameFilter}%")) ||
                (string.IsNullOrWhiteSpace(query.Alpha3Filter) && c.Alpha3Code.Equals(query.Alpha3Filter, StringComparison.InvariantCultureIgnoreCase))).GetPaged(query.CurrentPage, query.PageSize);

            if (countries?.RowCount > 0)
            {
                returnValue.Data = countries;
            }
            else
            {
                returnValue.InfoMessages.Add("No Countries Found");
            }
            return returnValue;
        }

        public IActionResponse<Domain.Models.Country> FetchSingle(long Id)
        {
            var returnValue = new ActionResponse<Domain.Models.Country>();
            var country = _context.Countries.Find(Id);
            if (country == null || country.Id < 1)
            {
                returnValue.ErrorMessages.Add("Country Not Found");
                return returnValue;
            }
            returnValue.Success = true;
            returnValue.Data = country;
            return returnValue;
        }

        public IDataTransferImportResponse<Domain.Models.Country> Import(IDataTransferImport<Domain.Models.Country> import)
        {
            throw new NotImplementedException();
        }

        public IActionResponse<Domain.Models.Country> Persist(Domain.Models.Country entity)
        {
            var returnValue = new ActionResponse<Domain.Models.Country>
            {
                Success = true,
                Data = entity
            };
            var existing = _context.Countries.Where(c => (entity.Id > 0 && c.Id.Equals(entity.Id)) ||
                c.EnglishName.Equals(entity.EnglishName, StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault();
            if (existing?.Id > 0)
            {
                //Update
                entity.Id = existing.Id;
                existing.Merge(entity);
                _context.Countries.Update(existing);
                returnValue.Data = existing;
                return returnValue;
            }

            if (entity.Id > 0)
            {
                //Invalid Id
                returnValue.Success = false;
                returnValue.ErrorMessages.Add("Country with this Id Not Found");
                return returnValue;
            }
            //Insert
            _context.Countries.Add(entity);
            return returnValue;
        }

        public IActionResponse<int> CommitChanges()
        {
            var returnValue = new ActionResponse<int> { Success = true };
            try
            {
                returnValue.Data = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                returnValue.Success = false;
                returnValue.ErrorMessages.Add($"Error during commit: {ex.Message}");
            }
            return returnValue;
        }
    }
}
