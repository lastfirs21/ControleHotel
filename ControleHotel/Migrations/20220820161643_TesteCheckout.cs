using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleHotel.Migrations
{
    public partial class TesteCheckout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodoDeDias",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "PeriodoDeDias",
                table: "Hospedagems");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCheckOut",
                table: "Reservas",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCheckOut",
                table: "Hospedagems",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCheckOut",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "DataCheckOut",
                table: "Hospedagems");

            migrationBuilder.AddColumn<int>(
                name: "PeriodoDeDias",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeriodoDeDias",
                table: "Hospedagems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
