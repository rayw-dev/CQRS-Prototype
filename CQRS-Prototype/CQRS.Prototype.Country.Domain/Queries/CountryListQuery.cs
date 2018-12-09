using CQRS.Prototype.Country.Domain.Interfaces;
using CQRS_Prototype.Domain.Core.Interfaces;
using CQRS_Prototype.Domain.Models;
using MediatR;

namespace CQRS.Prototype.Country.Domain.Queries
{
    public class CountryListQuery : IRequest<IActionResponse<PagedResult<Models.Country>>>, ICountryListQuery
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string NameFilter { get; set; }
        public string Alpha3Filter { get; set; }
    }
}
