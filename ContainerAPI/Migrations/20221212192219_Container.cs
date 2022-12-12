using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContainerAPI.Migrations
{
    public partial class Container : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Containers",
                columns: table => new
                {
                    containerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    containerNumero = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    containerTipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    containerStatusVazio = table.Column<bool>(type: "bit", nullable: false),
                    containerCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Containers", x => x.containerId);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacoes",
                columns: table => new
                {
                    movimentacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    movimentacaoTipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    movimentacaoInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    movimentacaoFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    containerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacoes", x => x.movimentacaoId);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Containers_containerId",
                        column: x => x.containerId,
                        principalTable: "Containers",
                        principalColumn: "containerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_containerId",
                table: "Movimentacoes",
                column: "containerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacoes");

            migrationBuilder.DropTable(
                name: "Containers");
        }
    }
}
