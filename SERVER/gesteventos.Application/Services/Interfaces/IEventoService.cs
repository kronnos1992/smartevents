using gesteventos.Domain.Models;

namespace gesteventos.Application.Services.Interfaces
{
    public interface IEventoService
    {
        Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false);
        Task<Evento[]> GetEventosByTemaAsync(string tema, bool includePalestrante = false);
        Task<Evento> GetEventoByIdAsync(int id, bool includePalestrante = false);
        Task<Evento> InsertEvento(Evento evento);
        Task<Evento> UpdateEvento(int eventoId, Evento evento);
        Task<bool> DeleteEvento(int eventoId);
    }
}