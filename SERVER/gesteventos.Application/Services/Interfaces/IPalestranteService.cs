using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gesteventos.Domain.Models;

namespace gesteventos.Application.Services.Interfaces
{
    public interface IPalestranteService
    {
        //Palestrantes contract
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEvento = false);
        Task<Palestrante[]> GetPalestrantesByTemaAsync(string tema, bool includeEvento = false);
        Task<Palestrante> GetPalestranteByIdAsync(int id, bool includeEvento = false);
        Task<Palestrante> InsertPalestrante(Palestrante palestrante);
        Task<Palestrante> UpdatePalestrante(int palestranteId, Palestrante palestrante);
        Task<bool> DeletePalestrante(int palestranteId);
    }
}