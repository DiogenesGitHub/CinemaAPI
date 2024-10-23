using CinemaAPI.Models;
using CinemaAPI.Repositories.Interfaces;
using CinemaAPI.Services.Interfaces;


namespace CinemaAPI.Services
{
    public class SalaService : ISalaService
    {
        private readonly ISalaRepository _salaRepository;

        public SalaService(ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }

        public async Task<List<Sala>> GetAllSalasAsync()
        {
            return await _salaRepository.GetAllSalasAsync();
        }

        public async Task<Sala> GetSalaByIdAsync(int id)
        {
            return await _salaRepository.GetSalaByIdAsync(id);
        }

        public async Task CreateSalaAsync(Sala sala)
        {
            await _salaRepository.CreateSalaAsync(sala);
        }

        public async Task UpdateSalaAsync(Sala sala)
        {
            await _salaRepository.UpdateSalaAsync(sala);
        }

        public async Task DeleteSalaAsync(int id)
        {
            await _salaRepository.DeleteSalaAsync(id);
        }
    }
}