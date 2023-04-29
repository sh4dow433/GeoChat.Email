using GeoChat.Email.EventBus;
using GeoChat.Email.RabbitMqEventBus.ConnectionManager;
using GeoChat.Email.RabbitMqEventBus.EventsManager;
using Microsoft.Extensions.DependencyInjection;

namespace GeoChat.Email.RabbitMqEventBus.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterEventBus(this IServiceCollection services)
    {
        services.AddSingleton<IEventManager, EventManager>();
        services.AddSingleton<IRabbitMqConnectionManager, RabbitMqConnectionManager>();
        services.AddSingleton<IEventBus, EventBus>();
    }
}
