using ControleLocacao.Infra.Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace ControleLocacao.Infra.Data.Configurations
{
    public class LocacaoConfiguration : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> b)
        {
            b.ToTable(nameof(Locacao));

            #region Campos

            b.HasKey(nameof(Locacao.Id));
            b.Property(nameof(Locacao.Id))
                .ValueGeneratedOnAdd();

            b.Property(b => b.ClienteId)
                .HasColumnName(nameof(Locacao.ClienteId))
                .IsRequired();

            b.Property(b => b.VeiculoId)
                .HasColumnName(nameof(Locacao.VeiculoId))
                .IsRequired();


            b.Property(b=>b.DataRetirada)
                .HasColumnName(nameof(Locacao.DataRetirada))
                .IsRequired();

            b.Property(b => b.DataLimite)
               .HasColumnName(nameof(Locacao.DataLimite))
               .IsRequired();

            b.Property(b => b.DataEntrega)
               .HasColumnName(nameof(Locacao.DataEntrega));

            b.Property(b => b.ValorDiaria)
               .HasColumnName(nameof(Locacao.ValorDiaria))
               .HasColumnType("double(16,2)")
               .IsRequired();

            b.Property(b => b.ValorSeguro)
               .HasColumnName(nameof(Locacao.ValorSeguro))
               .HasColumnType("double(16,2)")
               .IsRequired();

            b.Property(b => b.DiariasPrevistas)
                .HasColumnName(nameof(Locacao.DiariasPrevistas))
                .IsRequired();

            b.Property(b => b.TotalPrevisto)
               .HasColumnName(nameof(Locacao.TotalPrevisto))
               .HasColumnType("double(16,2)")
               .IsRequired();

            b.Property(b => b.DiariasRealizada)
                .HasColumnName(nameof(Locacao.DiariasRealizada));

            b.Property(b => b.TotalPago)
               .HasColumnName(nameof(Locacao.TotalPago))
               .HasColumnType("double(16,2)");


            #endregion


            #region Indices

            b.HasOne(o => o.Cliente)
               .WithMany(d => d.Locacoes)
               .HasForeignKey(fk => fk.ClienteId)
               .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(o => o.Veiculo)
               .WithMany(d => d.Locacoes)
               .HasForeignKey(fk => fk.VeiculoId)
               .OnDelete(DeleteBehavior.Restrict);

            b.HasIndex(c => c.DataRetirada)
                .HasDatabaseName($"IX_{nameof(Locacao)}_{nameof(Locacao.DataRetirada)}");

            b.HasIndex(c => c.DataLimite)
                .HasDatabaseName($"IX_{nameof(Locacao)}_{nameof(Locacao.DataLimite)}");

            b.HasIndex(c => c.DataEntrega)
                .HasDatabaseName($"IX_{nameof(Locacao)}_{nameof(Locacao.DataEntrega)}");

            #endregion
        }
    }
}
