using System.Collections.Generic;
using Roknoe.Core.Contracts.Databases.Events;

namespace Roknoe.Core.Contracts.Databases.Participants
{
    public class Participant
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}