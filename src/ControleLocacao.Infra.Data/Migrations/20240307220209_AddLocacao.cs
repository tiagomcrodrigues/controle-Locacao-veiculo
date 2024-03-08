using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleLocacao.Infra.Data.Migrations
{
    public partial class AddLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    VeiculoId = table.Column<int>(type: "int", nullable: false),
                    DataRetirada = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataLimite = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ValorDiaria = table.Column<double>(type: "double(16,2)", nullable: false),
                    ValorSeguro = table.Column<double>(type: "double(16,2)", nullable: false),
                    DiariasPrevistas = table.Column<int>(type: "int", nullable: false),
                    TotalPrevisto = table.Column<double>(type: "double(16,2)", nullable: false),
                    DiariasRealizada = table.Column<int>(type: "int", nullable: false),
                    TotalPago = table.Column<double>(type: "double(16,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locacao_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locacao_Veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_ClienteId",
                table: "Locacao",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_DataEntrega",
                table: "Locacao",
                column: "DataEntrega");

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_DataLimite",
                table: "Locacao",
                column: "DataLimite");

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_DataRetirada",
                table: "Locacao",
                column: "DataRetirada");

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_VeiculoId",
                table: "Locacao",
                column: "VeiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locacao");
        }
    }
}
