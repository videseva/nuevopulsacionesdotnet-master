using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class UpdateBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradors",
                columns: table => new
                {
                    Cedula = table.Column<string>(nullable: false),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Sexo = table.Column<string>(nullable: true),
                    Usuario = table.Column<string>(nullable: true),
                    Contrasenia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradors", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Cedula = table.Column<string>(nullable: false),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Sexo = table.Column<string>(nullable: true),
                    Ocupacion = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Estado = table.Column<int>(nullable: false),
                    ParcialTeorico = table.Column<int>(nullable: false),
                    ParcialPractico = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Cedula = table.Column<string>(nullable: false),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Sexo = table.Column<string>(nullable: true),
                    Usuario = table.Column<string>(nullable: true),
                    Contrasenia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Cedula);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradors");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
