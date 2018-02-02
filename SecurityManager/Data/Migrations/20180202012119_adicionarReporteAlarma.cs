using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SecurityManager.Data.Migrations
{
    public partial class adicionarReporteAlarma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AlarmaId",
                table: "Alarma",
                newName: "ReporteAlarmaId");

            migrationBuilder.AddColumn<string>(
                name: "Alarma",
                table: "Alarma",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comentarios",
                table: "Alarma",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Funciona",
                table: "Alarma",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alarma",
                table: "Alarma");

            migrationBuilder.DropColumn(
                name: "Comentarios",
                table: "Alarma");

            migrationBuilder.DropColumn(
                name: "Funciona",
                table: "Alarma");

            migrationBuilder.RenameColumn(
                name: "ReporteAlarmaId",
                table: "Alarma",
                newName: "AlarmaId");
        }
    }
}
