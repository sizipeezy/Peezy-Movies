namespace PeezyMovies.Core.Models
{
    using PeezyMovies.Infrastructure.Data.Models;
    using System.Collections.Generic;


    public class ActorsDropDownViewModel
    {
        public ActorsDropDownViewModel()
        {
            this.Actors = new List<Actor>();
        }
        public List<Actor> Actors { get; set; } 
    }
}
