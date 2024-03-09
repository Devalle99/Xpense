using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xpense.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class esperemosquesealaultima : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
