using System;

namespace Marebor.Voting.Core.Messaging.Events
{
    public abstract class FailureEventBase : EventBase
    {
        public string Error { get; set; }
    }
}
