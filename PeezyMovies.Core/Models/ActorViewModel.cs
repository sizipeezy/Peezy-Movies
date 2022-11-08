namespace PeezyMovies.Core.Models
{
    using PeezyMovies.Infrastructure.Data.Models;
    using System.Collections.Generic;


    public class ActorViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }

        public string FullName { get; set; }

        public string? Bio { get; set; }

        public List<ActorMovie> Movies { get; set; } = new List<ActorMovie>();
    }
}
