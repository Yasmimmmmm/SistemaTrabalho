using Microsoft.EntityFrameworkCore;
using SistemadeTrabalho2.Data.Map;
using SistemadeTrabalho2.Models;

namespace SistemadeTrabalho2.Data
{
    public class SistemaTarefaDbContext : DbContext
    {
        public SistemaTarefaDbContext(DbContextOptions<SistemaTarefaDbContext> options)
            : base(options)
        {
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<PediProdModel> PediProds { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new PediProdMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
