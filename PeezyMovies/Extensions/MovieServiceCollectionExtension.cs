namespace Microsoft.Extensions.DependencyInjection
{
    using PeezyMovies.Infrastructure.Data.Common;

    public static class MovieServiceCollectionExtension
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IRepository, Repository>();

            return services;
        }
    }
}
