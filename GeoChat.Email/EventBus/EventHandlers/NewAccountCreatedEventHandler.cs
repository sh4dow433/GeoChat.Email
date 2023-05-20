using GeoChat.Email.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoChat.Email.EventBus.EventHandlers;

internal class NewAccountCreatedEventHandler : IEventHandler<NewAccountCreatedEvent>
{
    public NewAccountCreatedEventHandler()
    {

    }
    public Task HandleAsync(NewAccountCreatedEvent @event)
    {
        throw new NotImplementedException();
    }
}
