
namespace PeezyMovies.Infrastructure.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PeezyMovies.Infrastructure.Data.Models;
    using System.Collections.Generic;

    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.HasData(SeedCinemas());
        }

        private List<Cinema> SeedCinemas()
        {
            var cinemas = new List<Cinema>();
            cinemas.AddRange(new Cinema[]
            {
                 new Cinema {Id=2, Name = "Cinema City", Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg", Description = "Mall of Sofia"},
                new Cinema {Id = 3,  Name = "CineGrand", Logo="https://s.inyourpocket.com/gallery/274666.jpg",  Description = "Movie Theatre located in Sofia"},
                new Cinema {Id = 4,  Name = "Kino Odeaon", Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg", Description ="Description of Movie 4" },
                new Cinema {Id = 5,  Name = "Imaxx Cinema", Logo= "http://dotnethow.net/images/cinemas/cinema-3.jpeg", Description = "Cinema 4 Description" },
                new Cinema {Id = 6,  Name = "Cinema 5", Logo= "http://dotnethow.net/images/cinemas/cinema-5.jpeg", Description = "Cinmea 5 Descirpiton" },
            });

            return cinemas;
        }
    }
}
