using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CodingEventsDemo.Models
{
    public class Event 
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string Location { get; set; }

        public int Attending { get; set; }
        public string ContactEmail { get; set; }
        public int Id { get; }
        private static int nextId = 1;

        public Event()
        {
            Id = nextId;
            nextId++;
        }


        public Event(string name, string description, string location, int attending, string contactEmail) : this()
        {
            Name = name;
            Description = description;
            Location = location;
            Attending = attending;
            ContactEmail = contactEmail;
            
        } 
        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
