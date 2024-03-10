using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xpense.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_fecha_to_expense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("398791a8-38c0-46d5-875c-aecbe3636ff6"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOjnxnQrmnk392nYuqFEcFgtwnkFc0JKc/X55XpOHwYokLQS5SIaPhjgn427+zCX0A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4406ace7-f597-46b1-8d16-e828d724e8bd"),
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDX6TRs8w+rDBUFIKpcuRCxcom3xrn+XAtkor+SUSyl0LxcJVKPk5XtxRJ0rIxeu8w==");
        }
    }
}
