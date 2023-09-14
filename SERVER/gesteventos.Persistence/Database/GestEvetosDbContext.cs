using gesteventos.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace gesteventos.Persistence.Database
{
    public class GestEvetosDbContext : DbContext
    {
        public GestEvetosDbContext(DbContextOptions<GestEvetosDbContext> options) : base(options)
        {

        }

        public DbSet<Evento> Tb_Eventos { get; set; }
        public DbSet<Palestrante> Tb_Palestrantes { get; set; }
        public DbSet<RedeSocial> Tb_RedeSociais { get; set; }
        public DbSet<Lote> Tb_Lotes { get; set; }
        public DbSet<EventoPalestrante> Tb_EventoPalestrantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventoPalestrante>()
                .HasKey(e => new { e.EventoId, e.PalestranteId });

            modelBuilder.Entity<Evento>()
                .HasMany(e => e.RedesSociais)
                .WithOne(e => e.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>()
               .HasMany(e => e.RedeSocials)
               .WithOne(e => e.Palestrante)
               .OnDelete(DeleteBehavior.Cascade);

        }
    }
}