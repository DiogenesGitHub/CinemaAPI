using CinemaAPI.Models;

namespace CinemaAPI.Repositories.Interfaces
{
    public interface IFilmeRepository
    {
        Task<List<Filme>> GetAllFilmesAsync();
        Task<Filme> GetFilmeByIdAsync(int id);
        Task CreateFilmeAsync(Filme filme);
        Task UpdateFilmeAsync(Filme filme);
        Task DeleteFilmeAsync(int id);
    }
}
