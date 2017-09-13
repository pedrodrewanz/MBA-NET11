using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.MasterChef.Migrations
{
    public partial class CamposObrigatorios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receita_Categoria_CategoriaID",
                schema: "MasterChef",
                table: "Receita");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                schema: "MasterChef",
                table: "Receita",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModoPreparo",
                schema: "MasterChef",
                table: "Receita",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                schema: "MasterChef",
                table: "Receita",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaID",
                schema: "MasterChef",
                table: "Receita",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TipoMedida",
                schema: "MasterChef",
                table: "Ingrediente",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                schema: "MasterChef",
                table: "Ingrediente",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                schema: "MasterChef",
                table: "Categoria",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Receita_Categoria_CategoriaID",
                schema: "MasterChef",
                table: "Receita",
                column: "CategoriaID",
                principalSchema: "MasterChef",
                principalTable: "Categoria",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receita_Categoria_CategoriaID",
                schema: "MasterChef",
                table: "Receita");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                schema: "MasterChef",
                table: "Receita",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ModoPreparo",
                schema: "MasterChef",
                table: "Receita",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                schema: "MasterChef",
                table: "Receita",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaID",
                schema: "MasterChef",
                table: "Receita",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "TipoMedida",
                schema: "MasterChef",
                table: "Ingrediente",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                schema: "MasterChef",
                table: "Ingrediente",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                schema: "MasterChef",
                table: "Categoria",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_Receita_Categoria_CategoriaID",
                schema: "MasterChef",
                table: "Receita",
                column: "CategoriaID",
                principalSchema: "MasterChef",
                principalTable: "Categoria",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
