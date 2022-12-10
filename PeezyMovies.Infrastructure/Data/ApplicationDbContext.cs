namespace PeezyMovies.Infrastructure.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PeezyMovies.Infrastructure.Data.Configuration;
    using PeezyMovies.Infrastructure.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Actor>  Actors { get; set; }

        public DbSet<ActorMovie> ActorsMovies { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<MovieCategories> MoviesCategories { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrdersItems { get; set; }

        public DbSet<UserMovie> UsersMovies { get; set; }

        public DbSet<Item> Items { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MovieCategories>()
               .HasKey(x => new { x.MovieId, x.CategoryId });
            builder.Entity<UserMovie>()
                .HasKey(x => new { x.UserId, x.MovieId });

            builder.Entity<ActorMovie>()
                .HasKey(x => new { x.MovieId, x.ActorId });

            builder.Entity<OrderItem>()
                .HasKey(x => new { x.OrderId, x.MovieId });

            builder.Entity<Movie>()
            .Property(o => o.Rating)
            .HasColumnType("decimal(18,4)");

            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new CinemaConfiguration());
            builder.ApplyConfiguration(new ActorConfiguration());
            builder.ApplyConfiguration(new ProducersConfiguration());
            builder.ApplyConfiguration(new MovieConfiguration());

            base.OnModelCreating(builder);
        }
    }
}