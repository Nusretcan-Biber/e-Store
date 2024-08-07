using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class duzetlmeler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Guid",
                keyValue: new Guid("a49c7554-02c0-4057-8173-fc7275741137"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 6, 13, 20, 53, 41, DateTimeKind.Utc).AddTicks(4339));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Guid",
                keyValue: new Guid("a49c7554-02c0-4057-8173-fc7275741137"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 6, 12, 12, 54, 205, DateTimeKind.Utc).AddTicks(6575));
        }
    }
}
