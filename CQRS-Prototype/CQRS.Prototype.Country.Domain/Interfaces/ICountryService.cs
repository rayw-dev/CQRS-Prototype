using CQRS_Prototype.Domain.Core.Interfaces;
using CQRS_Prototype.Domain.Interfaces;
using CQRS_Prototype.Domain.Models;
using System.Threading.Tasks;

namespace CQRS.Prototype.Country.Domain.Interfaces
{
    public interface ICountryService : IDataTransferService<Models.Country>
    {
        Task<IActionResponse<PagedResult<Models.Country>>> FetchList(ICountryListQuery query);
        Task<IActionResponse<Models.Country>> FetchSingle(long Id);
        Task<IActionResponse<Models.Country>> FetchByEnglishName(string country);
        Task<IActionResponse<Models.Country>> FetchByLocalName(string country);
        Task<IActionResponse<Models.Country>> FetchByAlpha2Code(string code);
        Task<IActionResponse<Models.Country>> FetchByAlpha3Code(string code);
        Task<IActionResponse<Models.Country>> FetchByNumericCode(int code);
    }
}
