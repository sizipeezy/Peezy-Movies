namespace Microsoft.Extensions.DependencyInjection
{
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Services;
    using PeezyMovies.Infrastructure.Data.Common;

    public static class MovieServiceCollectionExtension
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<ICinemaService, CinemaService>();
         

            return services;
        }
    }
}
