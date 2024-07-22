using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreRelationshipDemo.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int ReleaseYear { get; set; }

        public List<Actor> Actors { get; set; } = new();

        // Set Many to Many relation through MovieActor
        public List<MovieActor> MovieActors = new();
    }
}