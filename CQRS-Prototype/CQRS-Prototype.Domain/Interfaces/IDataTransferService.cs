using CQRS_Prototype.Domain.Core.Interfaces;

namespace CQRS_Prototype.Domain.Interfaces
{
    public interface IDataTransferService<T> where T : class
    {
        IDataTransferImportResponse<T> Import(IDataTransferImport<T> import);
        IActionResponse<T> Persist(T entity);
        IActionResponse<T> Delete(T entity);
        IActionResponse<int> CommitChanges();
    }
}
