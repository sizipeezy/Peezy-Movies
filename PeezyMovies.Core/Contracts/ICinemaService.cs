namespace PeezyMovies.Core.Contracts
{
    using PeezyMovies.Core.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public interface ICinemaService
    {
        Task<bool> Exists(int id);
        Task<IEnumerable<CinemaViewModel>> GetAllAsync();

        Task AddCinemaAsync(AddCinemaViewModel model);

        Task DeleteCinemaAsync(int cinemaId);

        Task UpdateCinemaAsync(AddCinemaViewModel model, int cinemaId);

        AddCinemaViewModel GetById(int movieId);

        Task<CinemaViewModel> GetByIdAsync(int cinemaId);
    }
}
