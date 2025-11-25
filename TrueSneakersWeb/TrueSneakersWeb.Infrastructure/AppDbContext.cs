using Microsoft.EntityFrameworkCore;
using TrueSneakersWeb.Domain;

namespace TrueSneakersWeb.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().Property(p => p.Preco).HasColumnType("decimal(18,2)");
        }
    }
}