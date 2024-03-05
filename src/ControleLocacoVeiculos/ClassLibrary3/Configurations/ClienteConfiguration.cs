using ControleLocacao.Infra.Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleLocacao.Infra.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> b)
        {
            b.ToTable(nameof(Cliente));   

            #region Campos

            b.HasKey(nameof(Cliente.Id));
            b.Property(nameof(Cliente.Id))
                .ValueGeneratedOnAdd();

            b.Property(b => b.Nome)
                .HasColumnName(nameof(Cliente.Nome))
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            b.Property(b =>b.TipoPessoa)
                .HasColumnName(nameof(Cliente.TipoPessoa))
                .HasColumnType("char(1)")
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.Documento)
                .HasColumnName(nameof(Cliente.Documento))
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsRequired();

           b.Property(b => b.Telefone)
                .HasColumnName(nameof(Cliente.Telefone))
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.Email)
                .HasColumnName(nameof(Cliente.Email))
                .HasMaxLength(254)
                .IsUnicode(false)
                .IsRequired();

            #endregion


            #region Indices

            b.HasIndex(c => c.Nome)
                .HasDatabaseName($"IX_{nameof(Cliente)}_{nameof(Cliente.Nome)}");

            b.HasIndex(c => c.Documento)
                .HasDatabaseName($"UK_{nameof(Cliente)}_{nameof(Cliente.Documento)}")
                .IsUnique();

            #endregion


        }
    }
}
