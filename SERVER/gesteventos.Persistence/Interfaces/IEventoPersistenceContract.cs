using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gesteventos.Domain.Models;

namespace gesteventos.Persistence.Interfaces
{
    public interface IEventoPersistenceContract
    {
        //Eventos contract
        Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false);
        Task<Evento[]> GetEventosByTemaAsync(string tema, bool includePalestrante = false);
        Task<Evento> GetEventoByIdAsync(int id, bool includePalestrante = false);
    }
}