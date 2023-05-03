﻿using GeoChat.Email.EventBus.EventHandlers;
using GeoChat.Email.EventBus.Events;

namespace GeoChat.Email.EventBus;

public interface IEventBus : IDisposable
{
    void PublishEvent<TEvent>(TEvent @event, string exchange, string exchangeType, string routingKey = "")
        where TEvent : BaseEvent;

    void Subscribe<TEvent, TEventHandler>()
        where TEvent : BaseEvent
        where TEventHandler : IEventHandler<TEvent>;

    void Unsubscribe<TEvent, TEventHandler>()
        where TEvent : BaseEvent
        where TEventHandler : IEventHandler<TEvent>;
}
