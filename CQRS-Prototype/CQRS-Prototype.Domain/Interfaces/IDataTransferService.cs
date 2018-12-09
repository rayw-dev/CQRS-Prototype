using CQRS_Prototype.Domain.Core.Interfaces;
using System.Threading.Tasks;

namespace CQRS_Prototype.Domain.Interfaces
{
    public interface IDataTransferService<T> where T : class
    {
        Task<IDataTransferImportResponse<T>> Import(IDataTransferImport<T> import);
        Task<IActionResponse<T>> Create(T entity);
        Task<IActionResponse<T>> Update(T entity);
        Task<IActionResponse<T>> Delete(T entity);
    }
}
