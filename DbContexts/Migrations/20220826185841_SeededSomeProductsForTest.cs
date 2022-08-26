using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.DbContexts.Migrations
{
    public partial class SeededSomeProductsForTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CountInStock", "Created", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 11, new DateTime(2022, 8, 26, 18, 58, 41, 317, DateTimeKind.Utc).AddTicks(6198), "Laptop", 15000.5 },
                    { 2, 123, new DateTime(2022, 8, 26, 18, 58, 41, 317, DateTimeKind.Utc).AddTicks(6201), "Mobile", 16000.5 },
                    { 3, 43, new DateTime(2022, 8, 26, 18, 58, 41, 317, DateTimeKind.Utc).AddTicks(6202), "Moza", 13600.299999999999 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
