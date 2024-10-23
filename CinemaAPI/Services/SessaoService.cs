using CinemaAPI.Models;
using CinemaAPI.Repositories.Interfaces;
using CinemaAPI.Services.Interfaces;

namespace CinemaAPI.Services
{
    public class SessaoService : ISessaoService
    {
        private readonly ISessaoRepository _sessaoRepository;

        public SessaoService(ISessaoRepository sessaoRepository)
        {
            _sessaoRepository = sessaoRepository;
        }

        public async Task<List<Sessao>> GetAllSessoesAsync()
        {
            return await _sessaoRepository.GetAllSessoesAsync();
        }

        public async Task<Sessao> GetSessaoByIdAsync(int id)
        {
            return await _sessaoRepository.GetSessaoByIdAsync(id);
        }

        public async Task CreateSessaoAsync(Sessao sessao)
        {
            await _sessaoRepository.CreateSessaoAsync(sessao);
        }

        public async Task UpdateSessaoAsync(Sessao sessao)
        {
            await _sessaoRepository.UpdateSessaoAsync(sessao);
        }

        public async Task DeleteSessaoAsync(int id)
        {
            await _sessaoRepository.DeleteSessaoAsync(id);
        }
    }
}