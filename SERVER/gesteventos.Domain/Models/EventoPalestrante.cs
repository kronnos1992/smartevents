using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gesteventos.Domain.Models
{
    public class EventoPalestrante
    {
        public int EventoId { get; set; }
        public int PalestranteId { get; set; }
        public DateTime DataCadastro { get; set; }
        public Palestrante? Palestrante { get; set; }
        public Evento? Evento { get; set; }
    }
}