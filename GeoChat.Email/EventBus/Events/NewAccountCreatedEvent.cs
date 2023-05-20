using GeoChat.Email.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoChat.Email.EventBus.Events;

internal class NewAccountCreatedEvent : BaseEvent
{
    public string UserId { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
}
