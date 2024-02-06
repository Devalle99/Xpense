using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xpense.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class cambiodecontrasenia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("398791a8-38c0-46d5-875c-aecbe3636ff6"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMtYMaOnDE7AJLtyVJUMGZ4ggCgWej5otMAUxrPMSRJ7oWXYuVrYIKQUNgXViZj36g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4406ace7-f597-46b1-8d16-e828d724e8bd"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEA82ETdY96xUdNwph0rlqj0d8ekCwCi+6/KG7247/iod90mVuldgKAUdaHBcAhMdmg==");
        }
    }
}
