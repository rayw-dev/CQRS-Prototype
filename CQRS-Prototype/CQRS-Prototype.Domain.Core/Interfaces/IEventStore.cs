using CQRS_Prototype.Domain.Core.Events;

namespace CQRS_Prototype.Domain.Core.Interfaces
{
    public interface IEventStore<TKey>
    {
        void Save<T>(T theEvent) where T : Event<TKey>;
    }
}
