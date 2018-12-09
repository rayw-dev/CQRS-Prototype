using MediatR;
using System;

namespace CQRS_Prototype.Domain.Core.Events
{
    public enum EventType
    {
        None = 0,
        Error = 1,
        Warning = 2,
        Info = 3,
        ResourceCreated = 4,
        ResourceUpdated = 5,
        ResourceDeleted = 6,
        Log = 7
    }

    public abstract class Event<TKey> : Message<TKey>, INotification
    {
        public EventType EventType { get; set; }

        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
