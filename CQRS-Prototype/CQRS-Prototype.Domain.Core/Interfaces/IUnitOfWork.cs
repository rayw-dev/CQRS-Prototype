using System;

namespace CQRS_Prototype.Domain.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IActionResponse<int> Commit();
    }
}
