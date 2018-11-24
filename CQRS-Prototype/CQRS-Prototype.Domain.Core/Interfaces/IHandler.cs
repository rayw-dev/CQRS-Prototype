using CQRS_Prototype.Domain.Core.Events;

namespace CQRS_Prototype.Domain.Core.Interfaces
{
    public interface IHandler<in T, TKey> where T : Message<TKey>
    {
        void Handle(T message);
    }
}
