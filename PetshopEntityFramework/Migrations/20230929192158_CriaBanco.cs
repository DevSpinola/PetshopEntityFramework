using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetshopEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class CriaBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animais",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datanasc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Especie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Raca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animais", x => x.AnimalId);
                });

            migrationBuilder.CreateTable(
                name: "Veterinarios",
                columns: table => new
                {
                    VeterinarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeVet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CRMV = table.Column<int>(type: "int", nullable: false),
                    DiasTrabalho = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinarios", x => x.VeterinarioId);
                });

            migrationBuilder.CreateTable(
                name: "ConsultasMedicas",
                columns: table => new
                {
                    ConsultaMedicaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataConsulta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MotivoConsulta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tratamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VeterinarioId = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    Concluida = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultasMedicas", x => x.ConsultaMedicaId);
                    table.ForeignKey(
                        name: "FK_ConsultasMedicas_Animais_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animais",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultasMedicas_Veterinarios_VeterinarioId",
                        column: x => x.VeterinarioId,
                        principalTable: "Veterinarios",
                        principalColumn: "VeterinarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasMedicas_AnimalId",
                table: "ConsultasMedicas",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasMedicas_VeterinarioId",
                table: "ConsultasMedicas",
                column: "VeterinarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultasMedicas");

            migrationBuilder.DropTable(
                name: "Animais");

            migrationBuilder.DropTable(
                name: "Veterinarios");
        }
    }
}
