using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Marebor.Voting.Core.Messaging.Commands
{
    public class AddCandidate : CommandBase, IRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
