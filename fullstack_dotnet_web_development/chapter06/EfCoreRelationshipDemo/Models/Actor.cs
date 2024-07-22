using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreRelationshipDemo.Models
{
    public class Actor
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Movie> Movies { get; set; } = new();

        // Set Many to Many relation through MovieActor
        public List<MovieActor> MovieActors = new();
    }
}