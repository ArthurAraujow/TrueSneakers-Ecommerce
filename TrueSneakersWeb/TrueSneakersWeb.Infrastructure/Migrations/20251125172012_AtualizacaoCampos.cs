using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrueSneakersWeb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "Produtos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tamanhos",
                table: "Produtos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UrlImagem",
                table: "Produtos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marca",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Tamanhos",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "UrlImagem",
                table: "Produtos");
        }
    }
}
