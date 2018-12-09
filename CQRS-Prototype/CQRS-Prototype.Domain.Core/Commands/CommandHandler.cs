﻿using CQRS_Prototype.Domain.Core.Events;
using CQRS_Prototype.Domain.Core.Interfaces;
using CQRS_Prototype.Domain.Core.Notifications;
using MediatR;

namespace CQRS_Prototype.Domain.Core.Commands
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        protected readonly IMediatorHandler Bus;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            Bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                Bus.RaiseEvent(new DomainNotification(EventType.Error, message.MessageType, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            if (_uow.Commit()) return true;

            Bus.RaiseEvent(new DomainNotification(EventType.Error, "Commit", "We had a problem during saving your data."));
            return false;
        }
    }
}
