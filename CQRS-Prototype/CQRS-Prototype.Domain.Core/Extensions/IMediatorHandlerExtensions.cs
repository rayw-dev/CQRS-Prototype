using CQRS_Prototype.Domain.Core.Events;
using CQRS_Prototype.Domain.Core.Interfaces;
using CQRS_Prototype.Domain.Core.Notifications;

namespace CQRS_Prototype.Domain.Core.Extensions
{
    public static class IMediatorHandlerExtensions
    {
        /// <summary>
        /// Send any error events from response
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="response"></param>
        /// <param name="errorKey"></param>
        public static void RaiseOnResponse(this IMediatorHandler handler, IActionResponse response, string errorKey)
        {
            if (handler == null || response == null || response.ErrorMessages == null || response.ErrorMessages.Count < 1) return;
            response.ErrorMessages.ForEach(async e =>
            {
                await handler.RaiseEvent(new DomainNotification(EventType.Error,
                    errorKey,
                    e));
            });
        }
    }
}
