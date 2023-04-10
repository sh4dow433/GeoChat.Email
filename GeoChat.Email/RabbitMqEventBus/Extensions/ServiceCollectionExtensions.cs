using GeoChat.Email.Api.EventBus;
using GeoChat.Email.Api.RabbitMqEventBus.ConnectionManager;
using GeoChat.Email.Api.RabbitMqEventBus.EventsManager;
using Microsoft.Extensions.DependencyInjection;

namespace GeoChat.Email.Api.RabbitMqEventBus.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterEventBus(this IServiceCollection services)
    {
        services.AddSingleton<IEventManager, EventManager>();
        services.AddSingleton<IRabbitMqConnectionManager, RabbitMqConnectionManager>();
        services.AddSingleton<IEventBus, EventBus>();
    }
}
