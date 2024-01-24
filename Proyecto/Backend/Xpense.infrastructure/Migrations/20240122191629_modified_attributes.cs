using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Xpense.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modified_attributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Expenses");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Expenses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("21e56e0e-cf41-4602-a8ba-e38853c26954"), null, "User", "USER" },
                    { new Guid("b1f6c811-53a5-4819-bb47-28861c5f5a74"), null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("4406ace7-f597-46b1-8d16-e828d724e8bd"), 0, "8f544974-8cdb-4865-b876-e6f632b78547", "admin@example.com", true, true, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEKN/F2iRFqi2r10tUc/VCLC412rxJF3ZzI2Owb/8sLkFBaRlipIooTiI/bKnK65dyg==", null, false, "WSC5KCXECFWP474KDDZNQOVKVZIRBGBS", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("b1f6c811-53a5-4819-bb47-28861c5f5a74"), new Guid("4406ace7-f597-46b1-8d16-e828d724e8bd") });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoriaId",
                table: "Expenses",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Categories_CategoriaId",
                table: "Expenses",
                column: "CategoriaId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Categories_CategoriaId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_CategoriaId",
                table: "Expenses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("21e56e0e-cf41-4602-a8ba-e38853c26954"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b1f6c811-53a5-4819-bb47-28861c5f5a74"), new Guid("4406ace7-f597-46b1-8d16-e828d724e8bd") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b1f6c811-53a5-4819-bb47-28861c5f5a74"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4406ace7-f597-46b1-8d16-e828d724e8bd"));

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
