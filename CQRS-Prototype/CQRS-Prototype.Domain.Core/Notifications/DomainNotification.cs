using CQRS_Prototype.Domain.Core.Events;
using System;

namespace CQRS_Prototype.Domain.Core.Notifications
{
    public class DomainNotification : Event<Guid>
    {
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }

        public DomainNotification(EventType type, string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            EventType = type;
            Version = 1;
            Key = key;
            Value = value;
        }
    }
}
