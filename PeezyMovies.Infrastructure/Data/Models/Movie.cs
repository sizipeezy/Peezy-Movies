namespace PeezyMovies.Infrastructure.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Title { get; set; }

        [Required]
        [MaxLength(40)]
        public string Director { get; set; }

        [Required]
        public decimal Rating { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [Range(20.0, 200.00)]
        public decimal Price { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
        [Required]
        public int ProducerId { get; set; }

        [ForeignKey(nameof(ProducerId))]
        public Producer Producer { get; set; }

        [Required]
        public int CinemaId { get; set; }

        [ForeignKey(nameof(CinemaId))]
        public Cinema Cinema { get; set; }

     
        [Required]
        public int GenreId { get; set; }


        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; }

        public List<UserMovie> UsersMovies { get; set; } = new List<UserMovie>();

        public List<ActorMovie> ActorsMovies { get; set; } = new List<ActorMovie>();

        public List<MovieCategories> MoviesCategories { get; set; } = new List<MovieCategories>();

    }
}
