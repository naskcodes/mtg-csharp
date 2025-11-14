using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mtg.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarLinhaQuantidadeUsuarioCartas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantidade",
                table: "usuarioCartas",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantidade",
                table: "usuarioCartas");
        }
    }
}
