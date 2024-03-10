using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xpense.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updated_userId_reference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_IdentityUser_UsuarioId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_IdentityUser_UsuarioId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_UsuarioId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UsuarioId",
                table: "Categories");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "Expenses",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("398791a8-38c0-46d5-875c-aecbe3636ff6"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEK0Qzub2NlWBWB2gUy3KxmRoCnyYbhy/QGEX5F9CHy1rFUswYw7HCZP+rutoW2j6rg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4406ace7-f597-46b1-8d16-e828d724e8bd"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEE2TlYqQ9mtyMH7TDHwakbyrcx6wuh2E2qyqELD5wLq20iao8dHpDg4xF4LirCecAw==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Expenses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("398791a8-38c0-46d5-875c-aecbe3636ff6"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENyL0DtFcvRWX9S5HwuRiXS/pUCl0MQB6fcSnZHwvgHSS60F3iKdeasqgQD39ECcbQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4406ace7-f597-46b1-8d16-e828d724e8bd"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFTUXLf7rt2EU0jJgQxbRFQaGNbj7Xc3R6AQjo3xlXDKeEZNVwoA02UaMmO3zPIfUg==");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_UsuarioId",
                table: "Expenses",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UsuarioId",
                table: "Categories",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_IdentityUser_UsuarioId",
                table: "Categories",
                column: "UsuarioId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_IdentityUser_UsuarioId",
                table: "Expenses",
                column: "UsuarioId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
