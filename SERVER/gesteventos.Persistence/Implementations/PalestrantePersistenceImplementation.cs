using gesteventos.Domain.Models;
using gesteventos.Persistence.Database;
using gesteventos.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gesteventos.Persistence.Implementations
{
    public class PalestrantePersistenceImplementation : IPalestrantePersistenceContract
    {
        private readonly GestEvetosDbContext dbContext;

        public PalestrantePersistenceImplementation(GestEvetosDbContext dbContext)
        {
            this.dbContext = dbContext;
            //evitar prisão de chaves
            this.dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = this.dbContext.Tb_Palestrantes
               .Include(p => p.RedeSocials);

            if (includeEventos)
            {
                query = query
                    .Include(p => p.Eventos)
                    .ThenInclude(p => p.Evento);
            }

            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Palestrante> GetPalestranteByIdAsync(int id, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = this.dbContext.Tb_Palestrantes
               .Include(p => p.RedeSocials);

            if (includeEventos)
            {
                query = query
                    .Include(p => p.Eventos)
                    .ThenInclude(p => p.Evento);
            }

            query = query.OrderBy(p => p.Id).Where(p => p.Id == id);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Palestrante[]> GetPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = this.dbContext.Tb_Palestrantes
               .Include(p => p.RedeSocials);

            if (includeEventos)
            {
                query = query
                    .Include(p => p.Eventos)
                    .ThenInclude(p => p.Evento);
            }

            query = query.OrderBy(p => p.NomeCompleto)
                         .Where(predicate: p => p.NomeCompleto.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

    }
}