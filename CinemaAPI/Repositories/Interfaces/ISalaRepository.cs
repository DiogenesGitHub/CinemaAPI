using CinemaAPI.Models;

namespace CinemaAPI.Repositories.Interfaces
{
    public interface ISalaRepository
    {
        Task<List<Sala>> GetAllSalasAsync();
        Task<Sala> GetSalaByIdAsync(int id);
        Task CreateSalaAsync(Sala sala);
        Task UpdateSalaAsync(Sala sala);
        Task DeleteSalaAsync(int id);
    }
}
