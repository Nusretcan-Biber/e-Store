using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class someTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_Guid",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Guid",
                keyValue: new Guid("a49c7554-02c0-4057-8173-fc7275741137"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 6, 12, 12, 54, 205, DateTimeKind.Utc).AddTicks(6575));

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryId",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Guid",
                keyValue: new Guid("a49c7554-02c0-4057-8173-fc7275741137"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 6, 10, 16, 39, 188, DateTimeKind.Utc).AddTicks(420));

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_Guid",
                table: "Product",
                column: "Guid",
                principalTable: "Category",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
