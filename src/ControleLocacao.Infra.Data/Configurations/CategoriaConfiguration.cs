﻿using ControleLocacao.Infra.Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleLocacao.Infra.Data.Configurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> b)
        {
            b.ToTable(nameof(Categoria));

            b.HasKey(nameof(Categoria.Id));
            b.Property(nameof(Categoria.Id))
                .ValueGeneratedOnAdd();

            b.Property(b => b.Nome)
                .HasColumnName(nameof(Categoria.Nome))
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.ValorSeguro)
                .HasColumnName(nameof(Categoria.ValorSeguro))
                .HasColumnType("decimal(16,2)")
                .IsRequired();

            b.Property(b => b.ValorDiaria)
                .HasColumnName(nameof(Categoria.ValorDiaria))
                .HasColumnType("decimal(16,2)")
                .IsRequired();

            b.HasIndex(c => c.Nome)
                .HasDatabaseName($"UK_{nameof(Categoria)}_{nameof(Categoria.Nome)}")
                .IsUnique();
        }
    }
}
