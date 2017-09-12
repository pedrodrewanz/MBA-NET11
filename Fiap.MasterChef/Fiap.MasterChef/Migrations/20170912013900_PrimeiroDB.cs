using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Fiap.MasterChef.Migrations
{
    public partial class PrimeiroDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MasterChef");

            migrationBuilder.CreateTable(
                name: "Categoria",
                schema: "MasterChef",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Receita",
                schema: "MasterChef",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoriaID = table.Column<int>(nullable: true),
                    Descricao = table.Column<string>(maxLength: 300, nullable: true),
                    ModoPreparo = table.Column<string>(nullable: true),
                    Titulo = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Receita_Categoria_CategoriaID",
                        column: x => x.CategoriaID,
                        principalSchema: "MasterChef",
                        principalTable: "Categoria",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingrediente",
                schema: "MasterChef",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: true),
                    Quantidade = table.Column<decimal>(type: "SMALLINT", nullable: false),
                    ReceitaID = table.Column<int>(nullable: true),
                    TipoMedida = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ingrediente_Receita_ReceitaID",
                        column: x => x.ReceitaID,
                        principalSchema: "MasterChef",
                        principalTable: "Receita",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediente_ReceitaID",
                schema: "MasterChef",
                table: "Ingrediente",
                column: "ReceitaID");

            migrationBuilder.CreateIndex(
                name: "IX_Receita_CategoriaID",
                schema: "MasterChef",
                table: "Receita",
                column: "CategoriaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingrediente",
                schema: "MasterChef");

            migrationBuilder.DropTable(
                name: "Receita",
                schema: "MasterChef");

            migrationBuilder.DropTable(
                name: "Categoria",
                schema: "MasterChef");
        }
    }
}
