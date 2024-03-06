using ControleLocacao.Infra.Data.Configurations;
using ControleLocacao.Infra.Data.Tables;
using Microsoft.EntityFrameworkCore;

namespace ControleLocacao.Infra.Data
{
    public class DbLocacao : DbContext
    {
        public DbLocacao(DbContextOptions<DbLocacao> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new VeiculoConfiguration());

        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Cliente> Clientees { get; set;}
        public virtual DbSet<Veiculo> Veiculoes { get;set; }

    }
}
