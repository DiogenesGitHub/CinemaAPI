using CinemaAPI.Models;

namespace CinemaAPI.Repositories.Interfaces
{
    public interface IExibicaoRepository
    {
        Task<List<Exibicao>> GetAllExibicoesAsync();
        Task<Exibicao> GetExibicaoByIdAsync(int id);
        Task CreateExibicaoAsync(Exibicao exibicao);
        Task UpdateExibicaoAsync(Exibicao exibicao);
        Task DeleteExibicaoAsync(int id);
    }
}
