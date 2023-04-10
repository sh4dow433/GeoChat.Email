using Microsoft.Extensions.DependencyInjection;
using GeoChat.Email.Api.RabbitMqEventBus.Extensions;
using Microsoft.Extensions.Hosting;

namespace GeoChat.Email;

public class Program
{
    public static async void Main(string[] args)
    {
        using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                //TODO: register handlers and email client;
                services.RegisterEventBus();
            })
            .Build();
        await host.StartAsync();
    }
}
