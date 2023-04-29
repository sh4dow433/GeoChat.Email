using GeoChat.Email.EventBus.Events;

namespace GeoChat.Email.EventBus.EventHandlers;

public interface IEventHandler<TEvent> where TEvent : BaseEvent
{
    Task HandleAsync(TEvent @event);
}
