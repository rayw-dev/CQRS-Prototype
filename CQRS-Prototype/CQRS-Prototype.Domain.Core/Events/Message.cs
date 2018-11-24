using MediatR;

namespace CQRS_Prototype.Domain.Core.Events
{
    public abstract class Message<TKey> : IRequest
    {
        public string MessageType { get; protected set; }
        public TKey AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
