namespace PeezyMovies.Infrastructure.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PeezyMovies.Infrastructure.Data.Models;


    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(SeedGenres());
        }

        private List<Genre> SeedGenres()
        {
            var result = new List<Genre>();

            result.AddRange(new Genre[]
            {
                new Genre { Id = 1, Name = "Horror" },
                new Genre { Id= 2,Name = "Action" },
                new Genre { Id= 3, Name = "Drama" },
                new Genre {  Id= 4,Name = "Fantasy" },
                new Genre {  Id= 5,Name = "Thriller" },
                new Genre { Id= 6, Name = "Mystery" },
                new Genre { Id= 7, Name = "Romantic" },
            });

          
            return result;
         
        }
    }
}
