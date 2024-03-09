using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xpense.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class cascadedeletecategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Categories_CategoriaId",
                table: "Expenses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("398791a8-38c0-46d5-875c-aecbe3636ff6"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIxUxBdlRnmefdTHY0vW4Ngr8Yugloqt8YZ40pvLUBvNSwGZ2cEFJLGHO9FXJTDSyg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4406ace7-f597-46b1-8d16-e828d724e8bd"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPyQ75ZdJ92Krq+asNbZsWR4afqzf3N0DTABwGTLApOaQW9YYs99Ee0ZCwF8KnfWQA==");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Categories_CategoriaId",
                table: "Expenses",
                column: "CategoriaId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Categories_CategoriaId",
                table: "Expenses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("398791a8-38c0-46d5-875c-aecbe3636ff6"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEITjy5wI3GmDOCNXdSNvW/mvrBthF9Zx8dpMeyLA1oqUxpoc2K8mrmBPkgCyeDCNFQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4406ace7-f597-46b1-8d16-e828d724e8bd"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPmR6/GfMI30wYwFRxBj4ar8F8AWLNN7Im7DG62wfFYQSfnFIKfXD+GqwMi87ro8KA==");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Categories_CategoriaId",
                table: "Expenses",
                column: "CategoriaId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
