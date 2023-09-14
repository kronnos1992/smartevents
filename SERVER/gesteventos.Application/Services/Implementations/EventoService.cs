using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gesteventos.Application.Services.Interfaces;
using gesteventos.Domain.Models;
using gesteventos.Persistence.Interfaces;

namespace gesteventos.Application.Services.Implementations
{
    public class EventoService : IEventoService
    {
        private readonly IPersistenceContract persistence;
        private readonly IEventoPersistenceContract eventoPersistence;

        public EventoService(IPersistenceContract persistence, IEventoPersistenceContract eventoPersistence)
        {
            this.persistence = persistence;
            this.eventoPersistence = eventoPersistence;
        }
        public async Task<Evento> InsertEvento(Evento evento)
        {
            try
            {
                this.persistence.Add(evento);
                if (await this.persistence.SaveChangesAsync())
                    return await eventoPersistence.GetEventoByIdAsync(evento.Id, false);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento evento)
        {
            try
            {
                var _evento = this.eventoPersistence.GetEventoByIdAsync(eventoId, false);
                if (_evento == null)
                    return null;

                evento.Id = _evento.Id;

                persistence.Update(evento);
                if (await this.persistence.SaveChangesAsync())
                    return await eventoPersistence.GetEventoByIdAsync(evento.Id, false);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await this.eventoPersistence.GetEventoByIdAsync(eventoId, false)
                    ?? throw new Exception("Evento não encontrado");

                persistence.Delete<Evento>(evento);
                return await this.persistence.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false)
        {
            try
            {
                var eventos = await this.eventoPersistence.GetAllEventosAsync(includePalestrante);
                if (eventos == null)
                    return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Evento> GetEventoByIdAsync(int id, bool includePalestrante = false)
        {
            try
            {
                var evento = await this.eventoPersistence.GetEventoByIdAsync(id, includePalestrante);
                if (evento == null) return null;
                return evento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Evento[]> GetEventosByTemaAsync(string tema, bool includePalestrante = false)
        {
            try
            {
                var evento = await this.eventoPersistence.GetEventosByTemaAsync(tema, includePalestrante);
                if (evento == null) return null;
                return evento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}