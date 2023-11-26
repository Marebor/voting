using System;
using System.ComponentModel.DataAnnotations;

namespace Marebor.Voting.Core.Messaging.Commands
{
    public abstract class CommandBase
    {
        [Required]
        public Guid CommandId { get; set; }
    }
}
