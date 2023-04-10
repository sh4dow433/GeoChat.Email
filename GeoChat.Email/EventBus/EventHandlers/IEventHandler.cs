using GeoChat.Email.Api.EventBus.Events;

namespace GeoChat.Email.Api.EventBus.EventHandlers;

public interface IEventHandler<TEvent> where TEvent : BaseEvent
{
    Task HandleAsync(TEvent @event);
}
