using MediatR;
using System;

namespace Marebor.Voting.Core.Messaging.Events
{
    public class CandidateAdded : EventBase, INotification
    {
        public string Name { get; set; }
    }
}
