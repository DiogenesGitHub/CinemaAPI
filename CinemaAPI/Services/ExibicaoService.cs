using CinemaAPI.Models;
using CinemaAPI.Repositories.Interfaces;
using CinemaAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaAPI.Services
{
    public class ExibicaoService : IExibicaoService
    {
        private readonly IExibicaoRepository _exibicaoRepository;

        public ExibicaoService(IExibicaoRepository exibicaoRepository)
        {
            _exibicaoRepository = exibicaoRepository;
        }

        public async Task<List<Exibicao>> GetAllExibicoesAsync()
        {
            return await _exibicaoRepository.GetAllExibicoesAsync();
        }

        public async Task<Exibicao> GetExibicaoByIdAsync(int id)
        {
            return await _exibicaoRepository.GetExibicaoByIdAsync(id);
        }

        public async Task CreateExibicaoAsync(Exibicao exibicao)
        {
            await _exibicaoRepository.CreateExibicaoAsync(exibicao);
        }

        public async Task UpdateExibicaoAsync(Exibicao exibicao)
        {
            await _exibicaoRepository.UpdateExibicaoAsync(exibicao);
        }

        public async Task DeleteExibicaoAsync(int id)
        {
            await _exibicaoRepository.DeleteExibicaoAsync(id);
        }
    }
}