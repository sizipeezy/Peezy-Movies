namespace PeezyMovies.Core.Contracts
{
    using PeezyMovies.Core.Models;
    using PeezyMovies.Infrastructure.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMovieService
    {
        Task<bool> Exists(int id);

        MovieViewModel MovieForView(int id);
        Task<IEnumerable<MovieViewModel>> GetAllAsync();

        Task AddMovieAsync(AddMovieViewModel model);

        AllMoviesViewModel All(AllMoviesViewModel model);

        IEnumerable<string> GenresNamesAsStrings();

        EditMovieViewModel GetById(int movieId);

        Task<Movie> GetMovieByIdAsync(int movieId);

        Task EditMovieAsync(AddMovieViewModel model, int movieId);

        Task AddMovieToCollectionAsync(string userId, int movieId);

        Task RemoveFromCollectionAsync(string userId, int movieId);

        Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId);

        Task<IEnumerable<Genre>> GetGenresAsync();

        Task<IEnumerable<Producer>> GetProducersAsync();

        Task<IEnumerable<Cinema>> GetCinemasAsync();

        Task<ActorsViewModel> GetActorsDropDown();
    }
}
