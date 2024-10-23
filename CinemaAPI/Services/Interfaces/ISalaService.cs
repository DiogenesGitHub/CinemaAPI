using CinemaAPI.Models;

namespace CinemaAPI.Services.Interfaces
{
    public interface ISalaService
    {
        Task<List<Sala>> GetAllSalasAsync();
        Task<Sala> GetSalaByIdAsync(int id);
        Task CreateSalaAsync(Sala sala);
        Task UpdateSalaAsync(Sala sala);
        Task DeleteSalaAsync(int id);
    }
}