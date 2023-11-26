using MediatR;

namespace Marebor.Voting.Core.Messaging.Commands
{
    public class AddVoter : CommandBase, IRequest
    {
        public string Name { get; set; }
    }
}
