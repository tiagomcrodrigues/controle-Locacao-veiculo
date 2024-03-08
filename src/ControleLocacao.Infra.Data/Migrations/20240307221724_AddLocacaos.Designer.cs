﻿// <auto-generated />
using System;
using ControleLocacao.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControleLocacao.Infra.Data.Migrations
{
    [DbContext(typeof(DbLocacao))]
    [Migration("20240307221724_AddLocacaos")]
    partial class AddLocacaos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ControleLocacao.Infra.Data.Tables.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.Property<decimal>("ValorDiaria")
                        .HasColumnType("decimal(16,2)")
                        .HasColumnName("ValorDiaria");

                    b.Property<decimal>("ValorSeguro")
                        .HasColumnType("decimal(16,2)")
                        .HasColumnName("ValorSeguro");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasDatabaseName("UK_Categoria_Nome");

                    b.ToTable("Categoria", (string)null);
                });

            modelBuilder.Entity("ControleLocacao.Infra.Data.Tables.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(14)
                        .IsUnicode(false)
                        .HasColumnType("varchar(14)")
                        .HasColumnName("Documento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .IsUnicode(false)
                        .HasColumnType("varchar(254)")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("Telefone");

                    b.Property<string>("TipoPessoa")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .HasColumnName("TipoPessoa");

                    b.HasKey("Id");

                    b.HasIndex("Documento")
                        .IsUnique()
                        .HasDatabaseName("UK_Cliente_Documento");

                    b.HasIndex("Nome")
                        .HasDatabaseName("IX_Cliente_Nome");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("ControleLocacao.Infra.Data.Tables.Locacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("ClienteId");

                    b.Property<DateTime?>("DataEntrega")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DataEntrega");

                    b.Property<DateTime>("DataLimite")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DataLimite");

                    b.Property<DateTime>("DataRetirada")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DataRetirada");

                    b.Property<int>("DiariasPrevistas")
                        .HasColumnType("int")
                        .HasColumnName("DiariasPrevistas");

                    b.Property<int?>("DiariasRealizada")
                        .HasColumnType("int")
                        .HasColumnName("DiariasRealizada");

                    b.Property<double?>("TotalPago")
                        .HasColumnType("double(16,2)")
                        .HasColumnName("TotalPago");

                    b.Property<double>("TotalPrevisto")
                        .HasColumnType("double(16,2)")
                        .HasColumnName("TotalPrevisto");

                    b.Property<double>("ValorDiaria")
                        .HasColumnType("double(16,2)")
                        .HasColumnName("ValorDiaria");

                    b.Property<double>("ValorSeguro")
                        .HasColumnType("double(16,2)")
                        .HasColumnName("ValorSeguro");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("int")
                        .HasColumnName("VeiculoId");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("DataEntrega")
                        .HasDatabaseName("IX_Locacao_DataEntrega");

                    b.HasIndex("DataLimite")
                        .HasDatabaseName("IX_Locacao_DataLimite");

                    b.HasIndex("DataRetirada")
                        .HasDatabaseName("IX_Locacao_DataRetirada");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Locacao", (string)null);
                });

            modelBuilder.Entity("ControleLocacao.Infra.Data.Tables.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AnoFabricacao")
                        .HasColumnType("int")
                        .HasColumnName("AnoFabricacao");

                    b.Property<int>("AnoModelo")
                        .HasColumnType("int")
                        .HasColumnName("AnoModelo");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int")
                        .HasColumnName("CategoriaId");

                    b.Property<ulong>("Inativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(0ul)
                        .HasColumnName("Inativo");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("Marca");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Modelo");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("varchar(7)")
                        .HasColumnName("Placa");

                    b.Property<string>("Versao")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Versao");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("Marca")
                        .HasDatabaseName("IX_Veiculo_Marca");

                    b.HasIndex("Modelo")
                        .HasDatabaseName("IX_Veiculo_Modelo");

                    b.HasIndex("Placa")
                        .HasDatabaseName("IX_Veiculo_Placa");

                    b.HasIndex("Versao")
                        .HasDatabaseName("IX_Veiculo_Versao");

                    b.ToTable("Veiculo", (string)null);
                });

            modelBuilder.Entity("ControleLocacao.Infra.Data.Tables.Locacao", b =>
                {
                    b.HasOne("ControleLocacao.Infra.Data.Tables.Cliente", "Cliente")
                        .WithMany("Locacoes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ControleLocacao.Infra.Data.Tables.Veiculo", "Veiculo")
                        .WithMany("Locacoes")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("ControleLocacao.Infra.Data.Tables.Veiculo", b =>
                {
                    b.HasOne("ControleLocacao.Infra.Data.Tables.Categoria", "Categoria")
                        .WithMany("Veiculos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("ControleLocacao.Infra.Data.Tables.Categoria", b =>
                {
                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("ControleLocacao.Infra.Data.Tables.Cliente", b =>
                {
                    b.Navigation("Locacoes");
                });

            modelBuilder.Entity("ControleLocacao.Infra.Data.Tables.Veiculo", b =>
                {
                    b.Navigation("Locacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
