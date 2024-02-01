using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xpense.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class relationship_expense_to_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Expenses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4406ace7-f597-46b1-8d16-e828d724e8bd"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDX6TRs8w+rDBUFIKpcuRCxcom3xrn+XAtkor+SUSyl0LxcJVKPk5XtxRJ0rIxeu8w==");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("398791a8-38c0-46d5-875c-aecbe3636ff6"), 0, "b876-e6f632b78547-8f544974-8cdb-4865-b876-e6f632b78547", "user@example.com", true, true, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEOjnxnQrmnk392nYuqFEcFgtwnkFc0JKc/X55XpOHwYokLQS5SIaPhjgn427+zCX0A==", null, false, "DDZNQOVKVZIRBGBSWSC5KCXECFWP474KDDZNQOVKVZIRBGBS", false, "user@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("21e56e0e-cf41-4602-a8ba-e38853c26954"), new Guid("398791a8-38c0-46d5-875c-aecbe3636ff6") });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("21e56e0e-cf41-4602-a8ba-e38853c26954"), new Guid("398791a8-38c0-46d5-875c-aecbe3636ff6") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("398791a8-38c0-46d5-875c-aecbe3636ff6"));

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4406ace7-f597-46b1-8d16-e828d724e8bd"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKN/F2iRFqi2r10tUc/VCLC412rxJF3ZzI2Owb/8sLkFBaRlipIooTiI/bKnK65dyg==");
        }
    }
}
