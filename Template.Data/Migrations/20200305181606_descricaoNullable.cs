using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class descricaoNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Descricao_descricao_id",
                table: "Filme");

            migrationBuilder.DropIndex(
                name: "IX_Filme_descricao_id",
                table: "Filme");

            migrationBuilder.AlterColumn<Guid>(
                name: "descricao_id",
                table: "Filme",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Filme_descricao_id",
                table: "Filme",
                column: "descricao_id",
                unique: true,
                filter: "[descricao_id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Filme_Descricao_descricao_id",
                table: "Filme",
                column: "descricao_id",
                principalTable: "Descricao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Descricao_descricao_id",
                table: "Filme");

            migrationBuilder.DropIndex(
                name: "IX_Filme_descricao_id",
                table: "Filme");

            migrationBuilder.AlterColumn<Guid>(
                name: "descricao_id",
                table: "Filme",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Filme_descricao_id",
                table: "Filme",
                column: "descricao_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Filme_Descricao_descricao_id",
                table: "Filme",
                column: "descricao_id",
                principalTable: "Descricao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
