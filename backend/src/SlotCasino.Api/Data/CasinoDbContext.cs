using Microsoft.EntityFrameworkCore;
using SlotCasino.Api.Models.Entities;

namespace SlotCasino.Api.Data
{
    public class CasinoDbContext : DbContext
    {
        public CasinoDbContext(DbContextOptions<CasinoDbContext> options) : base(options)
        {
        }

        public DbSet<Perfil> Perfiles { get; set; } = null!;
        public DbSet<Juego> Juegos { get; set; } = null!;
        public DbSet<ConfigJuego> ConfigJuegos { get; set; } = null!;
        public DbSet<Transaccion> Transacciones { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación ConfigJuego -> Juego (1 a 1)
            modelBuilder.Entity<ConfigJuego>()
                .HasOne(c => c.Juego)
                .WithOne()
                .HasForeignKey<ConfigJuego>(c => c.IdJuego)
                .IsRequired();

            // Relaciones Transaccion
            modelBuilder.Entity<Transaccion>()
                .HasOne(t => t.Perfil)
                .WithMany()
                .HasForeignKey(t => t.IdPerfil)
                .IsRequired();

            modelBuilder.Entity<Transaccion>()
                .HasOne(t => t.Juego)
                .WithMany()
                .HasForeignKey(t => t.IdJuego)
                .IsRequired(false); // No es requerido (puede ser un depósito)
        }
    }
}
