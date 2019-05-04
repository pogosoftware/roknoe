using System;
using System.Collections.Generic;

namespace Roknoe.Core.Contracts.Databases.Events
{
    public class Event
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public DateTime EventDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Place { get; set; }

        public DateTime EntriesTo { get; set; }

        public string Description { get; set; }

        public ICollection<Agenda> Agenda { get; set; }
    }
}