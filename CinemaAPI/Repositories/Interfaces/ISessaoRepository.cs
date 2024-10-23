using CinemaAPI.Models;

namespace CinemaAPI.Repositories.Interfaces
{
    public interface ISessaoRepository
    {
        Task<List<Sessao>> GetAllSessoesAsync();
        Task<Sessao> GetSessaoByIdAsync(int id);
        Task CreateSessaoAsync(Sessao sessao);
        Task UpdateSessaoAsync(Sessao sessao);
        Task DeleteSessaoAsync(int id);
    }
}
