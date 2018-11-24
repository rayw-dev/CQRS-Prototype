using CQRS_Prototype.Domain.Core.Commands;
using CQRS_Prototype.Domain.Core.Events;
using System;
using System.Threading.Tasks;

namespace CQRS_Prototype.Domain.Core.Interfaces
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event<Guid>;
    }
}
