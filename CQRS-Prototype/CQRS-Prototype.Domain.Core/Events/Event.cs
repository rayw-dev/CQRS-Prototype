using MediatR;
using System;

namespace CQRS_Prototype.Domain.Core.Events
{
    public abstract class Event<TKey> : Message<TKey>, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
