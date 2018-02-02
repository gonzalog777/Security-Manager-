using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SecurityManager.Data.Migrations
{
    public partial class accidentesepp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Alarma",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Accidente",
                columns: table => new
                {
                    ReporteAccidenteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Accidente = table.Column<string>(nullable: true),
                    Comentarios = table.Column<string>(nullable: true),
                    EmpleadoId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accidente", x => x.ReporteAccidenteId);
                    table.ForeignKey(
                        name: "FK_Accidente_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Epp",
                columns: table => new
                {
                    ReporteEppId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comentarios = table.Column<string>(nullable: true),
                    EmpleadoId = table.Column<int>(nullable: false),
                    Epp = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epp", x => x.ReporteEppId);
                    table.ForeignKey(
                        name: "FK_Epp_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accidente_EmpleadoId",
                table: "Accidente",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Epp_EmpleadoId",
                table: "Epp",
                column: "EmpleadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accidente");

            migrationBuilder.DropTable(
                name: "Epp");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Alarma");
        }
    }
}
