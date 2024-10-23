using CinemaAPI.Models;


namespace CinemaAPI.Services.Interfaces
{
    public interface IExibicaoService
    {
        Task<List<Exibicao>> GetAllExibicoesAsync();
        Task<Exibicao> GetExibicaoByIdAsync(int id);
        Task CreateExibicaoAsync(Exibicao exibicao);
        Task UpdateExibicaoAsync(Exibicao exibicao);
        Task DeleteExibicaoAsync(int id);
    }
}