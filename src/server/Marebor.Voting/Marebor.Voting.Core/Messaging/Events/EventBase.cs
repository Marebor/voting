using System;

namespace Marebor.Voting.Core.Messaging.Events
{
    public abstract class EventBase
    {
        public Guid CommandId { get; set; }
    }
}
