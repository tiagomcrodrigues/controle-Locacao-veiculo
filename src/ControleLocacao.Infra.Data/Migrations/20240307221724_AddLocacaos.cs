using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleLocacao.Infra.Data.Migrations
{
    public partial class AddLocacaos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TotalPago",
                table: "Locacao",
                type: "double(16,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double(16,2)");

            migrationBuilder.AlterColumn<int>(
                name: "DiariasRealizada",
                table: "Locacao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEntrega",
                table: "Locacao",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TotalPago",
                table: "Locacao",
                type: "double(16,2)",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double(16,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DiariasRealizada",
                table: "Locacao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEntrega",
                table: "Locacao",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);
        }
    }
}
