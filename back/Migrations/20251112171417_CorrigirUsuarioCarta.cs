using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mtg.Migrations
{
    /// <inheritdoc />
    public partial class CorrigirUsuarioCarta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarioCartas_cartas_CartasId",
                table: "usuarioCartas");

            migrationBuilder.DropForeignKey(
                name: "FK_usuarioCartas_usuarios_UsuariosId",
                table: "usuarioCartas");

            migrationBuilder.DropIndex(
                name: "IX_usuarioCartas_CartasId",
                table: "usuarioCartas");

            migrationBuilder.DropIndex(
                name: "IX_usuarioCartas_UsuariosId",
                table: "usuarioCartas");

            migrationBuilder.DropColumn(
                name: "CartasId",
                table: "usuarioCartas");

            migrationBuilder.DropColumn(
                name: "UsuariosId",
                table: "usuarioCartas");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioCartas_cartaId",
                table: "usuarioCartas",
                column: "cartaId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioCartas_usuarioId",
                table: "usuarioCartas",
                column: "usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarioCartas_cartas_cartaId",
                table: "usuarioCartas",
                column: "cartaId",
                principalTable: "cartas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuarioCartas_usuarios_usuarioId",
                table: "usuarioCartas",
                column: "usuarioId",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarioCartas_cartas_cartaId",
                table: "usuarioCartas");

            migrationBuilder.DropForeignKey(
                name: "FK_usuarioCartas_usuarios_usuarioId",
                table: "usuarioCartas");

            migrationBuilder.DropIndex(
                name: "IX_usuarioCartas_cartaId",
                table: "usuarioCartas");

            migrationBuilder.DropIndex(
                name: "IX_usuarioCartas_usuarioId",
                table: "usuarioCartas");

            migrationBuilder.AddColumn<int>(
                name: "CartasId",
                table: "usuarioCartas",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuariosId",
                table: "usuarioCartas",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuarioCartas_CartasId",
                table: "usuarioCartas",
                column: "CartasId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioCartas_UsuariosId",
                table: "usuarioCartas",
                column: "UsuariosId");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarioCartas_cartas_CartasId",
                table: "usuarioCartas",
                column: "CartasId",
                principalTable: "cartas",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarioCartas_usuarios_UsuariosId",
                table: "usuarioCartas",
                column: "UsuariosId",
                principalTable: "usuarios",
                principalColumn: "id");
        }
    }
}
