using gesteventos.Domain.Models;

namespace gesteventos.Persistence.Interfaces
{
    public interface IPalestrantePersistenceContract
    {
        //Palestrantes contract
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false);
        Task<Palestrante[]> GetPalestrantesByNomeAsync(string nome, bool includeEventos = false);
        Task<Palestrante> GetPalestranteByIdAsync(int id, bool includeEventos = false);
    }
}