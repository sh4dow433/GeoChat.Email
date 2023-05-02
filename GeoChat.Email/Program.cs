using Microsoft.Extensions.DependencyInjection;
using GeoChat.Email.RabbitMqEventBus.Extensions;
using Microsoft.Extensions.Hosting;
using GeoChat.Email.EventBus.EventHandlers;
using GeoChat.Email.EventBus.Events;
using GeoChat.Email.EventBus;

namespace GeoChat.Email;

public class Program
{
    public static async void Main(string[] args)
    {
        using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                //TODO: add email client;

                // event bus
                services.RegisterEventBus();

                // event handler
                // comment this line if u dont have a working rabbitmq connection
                services.AddTransient<IEventHandler<NewAccountCreatedEvent>, NewAccountCreatedEventHandler>();
            })
            .Build();

        /// comment these lines if u dont have a working rabbitmq connection:
        var bus = host.Services.GetService<IEventBus>();
        if (bus == null) throw new Exception("Event bus is null");
        bus.Subscribe<NewAccountCreatedEvent, NewAccountCreatedEventHandler>();
        ///

        await host.StartAsync();
    }
}
