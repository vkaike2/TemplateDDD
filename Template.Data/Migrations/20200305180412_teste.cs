using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "descricao_id",
                table: "Filme",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Descricao_descricao_id",
                table: "Filme");

            migrationBuilder.DropIndex(
                name: "IX_Filme_descricao_id",
                table: "Filme");

            migrationBuilder.DropColumn(
                name: "descricao_id",
                table: "Filme");
        }
    }
}
