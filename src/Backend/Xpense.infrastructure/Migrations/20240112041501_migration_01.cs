using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xpense.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migration_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "Expenses",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "Categories",
                newName: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Expenses",
                newName: "Usuario");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Categories",
                newName: "Usuario");
        }
    }
}
