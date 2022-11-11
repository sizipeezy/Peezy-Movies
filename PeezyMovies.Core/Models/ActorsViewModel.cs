namespace PeezyMovies.Core.Models
{
    using PeezyMovies.Infrastructure.Data.Models;
    using System.Collections.Generic;


    public class ActorsViewModel
    {
        public ActorsViewModel()
        {
            this.Actors = new List<Actor>();
        }
        public List<Actor> Actors { get; set; }
    }
}
