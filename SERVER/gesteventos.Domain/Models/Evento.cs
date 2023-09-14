namespace gesteventos.Domain.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string? Local { get; set; }
        public string? Tema { get; set; }
        public DateTime? EventoData { get; set; }
        public int QtdPessoas { get; set; }
        public string? ImgUrl { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public IEnumerable<Lote>? Lotes { get; set; }
        public IEnumerable<RedeSocial>? RedesSociais { get; set; }
        public IEnumerable<EventoPalestrante>? Palestrantes { get; set; }
    }
}