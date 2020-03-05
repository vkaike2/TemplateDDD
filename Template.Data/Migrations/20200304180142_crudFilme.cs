using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class crudFilme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    nome_filme = table.Column<string>(type: "varchar (30)", nullable: false),
                    faixaetaria = table.Column<string>(type: "varchar (30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_id_filme", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filme");
        }
    }
}
