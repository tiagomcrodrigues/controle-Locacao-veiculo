using ControleLocacao.Infra.Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleLocacao.Infra.Data.Configurations
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> b)
        {
            b.ToTable(nameof(Veiculo));

            b.HasKey(nameof(Veiculo.Id));
            b.Property(nameof(Veiculo.Id))
                .ValueGeneratedOnAdd();







        }
    }
}
