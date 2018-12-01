using CQRS_Prototype.Domain.Core.Interfaces;
using System.Linq;

namespace CQRS_Prototype.Domain.Interfaces
{
    public interface IRepository<T, TKey> where T : class
    {
        IActionResponse<T> Create(T entity);
        IActionResponse<T> Update(T entity);
        IActionResponse<T> Delete(TKey entityId);
        IActionResponse<T> GetById(TKey entityId);
        IActionResponse<IQueryable<T>> GetAll();
        IActionResponse<int> SaveChanges();
    }
}
