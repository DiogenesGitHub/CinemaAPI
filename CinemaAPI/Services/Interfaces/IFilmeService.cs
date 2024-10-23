using CinemaAPI.Models;


namespace CinemaAPI.Services.Interfaces
{
    public interface IFilmeService
    {
        Task<List<Filme>> GetAllFilmesAsync();
        Task<Filme> GetFilmeByIdAsync(int id);
        Task CreateFilmeAsync(Filme filme);
        Task UpdateFilmeAsync(Filme filme);
        Task DeleteFilmeAsync(int id);
    }
}