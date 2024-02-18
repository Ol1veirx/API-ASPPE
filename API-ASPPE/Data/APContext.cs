using API_ASPPE.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ASPPE.Data
{
    public class APContext : DbContext
    {
        public APContext(DbContextOptions<APContext> options) : base(options) 
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipe>()
                .HasOne<Torneio>(e => e.Torneio)
                .WithMany(t => t.Equipes)
                .HasForeignKey(e => e.TorneioId);
        }

        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Torneio> Torneios { get; set; }
        public DbSet<Etapa> Etapas { get; set; }
    }
}
