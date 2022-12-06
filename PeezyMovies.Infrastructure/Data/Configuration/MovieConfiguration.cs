namespace PeezyMovies.Infrastructure.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PeezyMovies.Infrastructure.Data.Models;

    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasData(SeedMovies());
        }

        private List<Movie> SeedMovies()
        {
            var movies = new List<Movie>();
            movies.AddRange(new Movie[]
            {
                new Movie{
                    Id = 1,
                    Director = "Valeri Milev",
                    Title = "Wrong Turn 7",
                    Rating= 8.0M,
                    ImageUrl = "amazon.com/images/M/MV5BM2Y5ZWE2MTMtODE3ZC00NWQ4LWJkNzctNGY4Njg5NDY5MzNlXkEyXkFqcGdeQXVyNjUxMjc1OTM@._V1_FMjpg_UX1000_.jpg",
                    Price = 50.00M,
                    Description = "Wrong Turn is an American horror film series created by Alan B. McElroy. The series consists of seven slasher film",
                    Trailer = "https://www.youtube.com/watch?v=ccaNMcPqpQ0&ab_channel=ONEMedia",
                    IsDeleted = false},

                 new Movie{
                    Id = 2,
                    Director = "Sam Raimi",
                    Title = "Doctor Strange",
                    Rating= 9.0M,
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSJ5IuxfEt-WmUIrpJldszdRJFfTubSEeQVMVNuv63Z0PNfvbWV",
                    Price = 25.00M,
                    Description = "Doctor Strange teams up with a mysterious teenage girl from his dreams who can travel across multiverse",
                    Trailer = "https://www.youtube.com/watch?v=aWzlQ2N6qqg&ab_channel=MarvelEntertainment",
                    IsDeleted = false},

                  new Movie{
                    Id = 3,
                    Director = "James Cameron",
                    Title = "Avatar 2",
                    Rating= 6.0M,
                    ImageUrl = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcSmGggtpJ4TX3aN3PUaVWUgNODHespRPvKYAyhGUAZSqSOmPiEm",
                    Price = 19.90M,
                    Description = "Jake Sully and Ney'tiri have formed a family and are doing everything to stay together. However, they must leave their home and explore the regions of Pandora.",
                    Trailer = "https://www.youtube.com/watch?v=d9MyW72ELq0&ab_channel=Avatar",
                    IsDeleted = false},
            });


            return movies;
        }
    }
}
