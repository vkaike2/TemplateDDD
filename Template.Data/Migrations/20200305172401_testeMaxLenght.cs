using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class testeMaxLenght : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "nome_filme",
                table: "Filme",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar (30)");

            migrationBuilder.AlterColumn<string>(
                name: "faixaetaria",
                table: "Filme",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar (30)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "nome_filme",
                table: "Filme",
                type: "varchar (30)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "faixaetaria",
                table: "Filme",
                type: "varchar (30)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);
        }
    }
}
