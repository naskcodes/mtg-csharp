using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace mtg.Migrations
{
    /// <inheritdoc />
    public partial class ColunaUsuarioEUsuarioCartas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    senha = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarioCartas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usuarioId = table.Column<int>(type: "integer", nullable: false),
                    cartaId = table.Column<int>(type: "integer", nullable: false),
                    CartasId = table.Column<int>(type: "integer", nullable: true),
                    UsuariosId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarioCartas", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuarioCartas_cartas_CartasId",
                        column: x => x.CartasId,
                        principalTable: "cartas",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_usuarioCartas_usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarioCartas_CartasId",
                table: "usuarioCartas",
                column: "CartasId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioCartas_UsuariosId",
                table: "usuarioCartas",
                column: "UsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_email",
                table: "usuarios",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarioCartas");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
