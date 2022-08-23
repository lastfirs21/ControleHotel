using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleHotel.Migrations
{
    public partial class AdicionandoPropriedadesAoHospede : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusReserva",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Hospedes",
                type: "text",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Hospedes",
                type: "text",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Hospedes",
                type: "text",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Hospedes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNasc",
                table: "Hospedes",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Hospedes",
                type: "text",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Hospedes",
                type: "text",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Rua",
                table: "Hospedes",
                type: "text",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "StatusHospedagem",
                table: "Hospedagems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusReserva",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Hospedes");

            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Hospedes");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Hospedes");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Hospedes");

            migrationBuilder.DropColumn(
                name: "DataNasc",
                table: "Hospedes");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Hospedes");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Hospedes");

            migrationBuilder.DropColumn(
                name: "Rua",
                table: "Hospedes");

            migrationBuilder.DropColumn(
                name: "StatusHospedagem",
                table: "Hospedagems");
        }
    }
}
