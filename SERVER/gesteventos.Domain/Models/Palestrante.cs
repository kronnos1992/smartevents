
namespace gesteventos.Domain.Models
{
    public class Palestrante
    {
        public int Id { get; set; }
        public string? NomeCompleto { get; set; }
        public string? MiniCv { get; set; }
        public string? ImgUrl { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public IEnumerable<EventoPalestrante>? Eventos { get; set; }
        public IEnumerable<RedeSocial>? RedeSocials { get; set; }
    }
}