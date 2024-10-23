using CinemaAPI.Models;
using CinemaAPI.Repositories.Interfaces;
using CinemaAPI.Services.Interfaces;


namespace CinemaAPI.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<List<Filme>> GetAllFilmesAsync()
        {
            return await _filmeRepository.GetAllFilmesAsync();
        }

        public async Task<Filme> GetFilmeByIdAsync(int id)
        {
            return await _filmeRepository.GetFilmeByIdAsync(id);
        }

        public async Task CreateFilmeAsync(Filme filme)
        {
            await _filmeRepository.CreateFilmeAsync(filme);
        }

        public async Task UpdateFilmeAsync(Filme filme)
        {
            await _filmeRepository.UpdateFilmeAsync(filme);
        }

        public async Task DeleteFilmeAsync(int id)
        {
            await _filmeRepository.DeleteFilmeAsync(id);
        }
    }
}