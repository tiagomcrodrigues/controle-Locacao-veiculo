using ControleLocacao.Infra.Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace ControleLocacao.Infra.Data.Configurations
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> b)
        {
            b.ToTable(nameof(Veiculo));

            #region Campos

            b.HasKey(nameof(Veiculo.Id));
            b.Property(nameof(Veiculo.Id))
                .ValueGeneratedOnAdd();

            b.Property(b => b.CategoriaId)
                .HasColumnName(nameof(Veiculo.CategoriaId))
                .IsRequired();
             
            b.Property(b=>b.Marca)
                .HasColumnName(nameof(Veiculo.Marca))
                .HasMaxLength(80)
                .IsRequired();

            b.Property(b => b.Modelo)
                .HasColumnName(nameof(Veiculo.Modelo))
                .HasMaxLength(50)
                .IsRequired();

            b.Property(b => b.Versao)
                .HasColumnName(nameof(Veiculo.Versao))
                .HasMaxLength(150)
                .IsRequired();

            b.Property(b => b.Placa)
                .HasColumnName(nameof(Veiculo.Placa))
                .HasMaxLength(7)
                .IsRequired();

            b.Property(b => b.AnoModelo)
                .HasColumnName(nameof(Veiculo.AnoModelo))
                .IsRequired();

            b.Property(b => b.AnoFabricacao)
                .HasColumnName(nameof(Veiculo.AnoFabricacao))
                .IsRequired();

            b.Property(b => b.Inativo)
                .HasColumnName(nameof(Veiculo.Inativo))
                .HasColumnType("bit")
                .HasDefaultValue(false)
                .IsRequired();

            #endregion


            #region Indices

            b.HasOne(o => o.Categoria)
               .WithMany(d => d.Veiculos)
               .HasForeignKey(fk => fk.CategoriaId)
               .OnDelete(DeleteBehavior.Restrict);


            b.HasIndex(c => c.Marca)
                .HasDatabaseName($"IX_{nameof(Veiculo)}_{nameof(Veiculo.Marca)}");

            b.HasIndex(c => c.Modelo)
                .HasDatabaseName($"IX_{nameof(Veiculo)}_{nameof(Veiculo.Modelo)}");

            b.HasIndex(c => c.Versao)
                .HasDatabaseName($"IX_{nameof(Veiculo)}_{nameof(Veiculo.Versao)}");

            b.HasIndex(c => c.Placa)
                .HasDatabaseName($"IX_{nameof(Veiculo)}_{nameof(Veiculo.Placa)}");

            #endregion
        }
    }
}
