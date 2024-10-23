using CinemaAPI.Models;

namespace CinemaAPI.Services.Interfaces
{
    public interface ISessaoService
    {
        Task<List<Sessao>> GetAllSessoesAsync();
        Task<Sessao> GetSessaoByIdAsync(int id);
        Task CreateSessaoAsync(Sessao sessao);
        Task UpdateSessaoAsync(Sessao sessao);
        Task DeleteSessaoAsync(int id);
    }
}