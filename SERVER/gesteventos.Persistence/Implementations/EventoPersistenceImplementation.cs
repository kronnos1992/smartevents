using gesteventos.Domain.Models;
using gesteventos.Persistence.Database;
using gesteventos.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gesteventos.Persistence.Implementations
{
    public class EventoPersistenceImplementation : IEventoPersistenceContract
    {
        private readonly GestEvetosDbContext dbContext;

        public EventoPersistenceImplementation(GestEvetosDbContext dbContext)
        {
            this.dbContext = dbContext;
            //evitar prisão de chaves
            this.dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false)
        {
            IQueryable<Evento> query = this.dbContext.Tb_Eventos
                .Include(p => p.Lotes)
                .Include(p => p.RedesSociais);

            if (includePalestrante)
            {
                query = query
                    .Include(p => p.Palestrantes)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderBy(p => p.DataCadastro);

            return await query.ToArrayAsync();
        }
        public async Task<Evento[]> GetEventosByTemaAsync(string tema, bool includePalestrante = false)
        {
            IQueryable<Evento> query = this.dbContext.Tb_Eventos
                .Include(p => p.Lotes)
                .Include(p => p.RedesSociais);

            if (includePalestrante)
            {
                query = query
                    .Include(p => p.Palestrantes)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderBy(p => p.EventoData).Where(p => p.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Evento> GetEventoByIdAsync(int id, bool includePalestrante = false)
        {
            IQueryable<Evento> query = this.dbContext.Tb_Eventos
                .Include(p => p.Lotes)
                .Include(p => p.RedesSociais);

            if (includePalestrante)
            {
                query = query
                    .Include(p => p.Palestrantes)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderBy(p => p.EventoData).Where(p => p.Id == id);

            return await query.FirstOrDefaultAsync();
        }

    }
}