using CQRS_Prototype.Domain.Core.Interfaces;
using CQRS_Prototype.Domain.Interfaces;
using CQRS_Prototype.Domain.Models;
using System.Threading.Tasks;

namespace CQRS.Prototype.Country.Domain.Interfaces
{
    public interface ICountryService : IDataTransferService<Models.Country>
    {
        IActionResponse<PagedResult<Models.Country>> FetchList(ICountryListQuery query);
        IActionResponse<Models.Country> FetchSingle(long Id);
        IActionResponse<Models.Country> FetchByEnglishName(string country);
        IActionResponse<Models.Country> FetchByLocalName(string country);
        IActionResponse<Models.Country> FetchByAlpha2Code(string code);
        IActionResponse<Models.Country> FetchByAlpha3Code(string code);
        IActionResponse<Models.Country> FetchByNumericCode(int code);
    }
}
