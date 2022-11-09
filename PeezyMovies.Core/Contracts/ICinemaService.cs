namespace PeezyMovies.Core.Contracts
{
    using PeezyMovies.Core.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public interface ICinemaService
    {
        Task<IEnumerable<CinemaViewModel>> GetAllAsync();

        Task AddCinemaAsync(AddCinemaViewModel model);

        Task DeleteCinemaAsync(int cinemaId);

        Task UpdateCinemaAsync(AddCinemaViewModel model, int cinemaId);

        AddCinemaViewModel GetById(int movieId);
    }
}
