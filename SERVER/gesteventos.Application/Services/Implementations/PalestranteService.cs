using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gesteventos.Application.Services.Interfaces;
using gesteventos.Domain.Models;
using gesteventos.Persistence.Interfaces;

namespace gesteventos.Application.Services.Implementations
{
    public class PalestranteService : IPalestranteService
    {
        private readonly IPersistenceContract persistence;
        private readonly IPalestrantePersistenceContract palestrantePersistence;
        public PalestranteService(IPersistenceContract persistence, IPalestrantePersistenceContract palestrantePersistence)
        {
            this.persistence = persistence;
            this.palestrantePersistence = palestrantePersistence;
        }
        public async Task<Palestrante> InsertPalestrante(Palestrante palestrante)
        {
            try
            {
                this.persistence.Add(palestrante);
                if (await this.persistence.SaveChangesAsync())
                    return await palestrantePersistence.GetPalestranteByIdAsync(palestrante.Id, false);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Palestrante> UpdatePalestrante(int palestranteId, Palestrante palestrante)
        {
            try
            {
                var _palestrante = this.palestrantePersistence.GetPalestranteByIdAsync(palestranteId, false);
                if (_palestrante == null)
                    return null;

                palestrante.Id = _palestrante.Id;

                persistence.Update(palestrante);
                if (await this.persistence.SaveChangesAsync())
                    return await palestrantePersistence.GetPalestranteByIdAsync(palestrante.Id, false);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeletePalestrante(int palestranteId)
        {
            try
            {
                var _palestrante = this.palestrantePersistence.GetPalestranteByIdAsync(palestranteId, false)
                    ?? throw new NullReferenceException("palestrante não encontrado");

                persistence.Delete(_palestrante);
                return await this.persistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEvento = false)
        {
            try
            {
                var palestrantes = await this.palestrantePersistence.GetAllPalestrantesAsync(includeEvento);
                if (palestrantes == null)
                    return null;

                return palestrantes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Palestrante> GetPalestranteByIdAsync(int id, bool includeEvento = false)
        {
            try
            {
                var palestrante = await this.palestrantePersistence.GetPalestranteByIdAsync(id, includeEvento);
                if (palestrante == null) return null;
                return palestrante;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Palestrante[]> GetPalestrantesByTemaAsync(string tema, bool includeEvento = false)
        {
            try
            {
                var palestrante = await this.palestrantePersistence.GetPalestrantesByNomeAsync(tema, includeEvento);
                if (palestrante == null) return null;
                return palestrante;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}