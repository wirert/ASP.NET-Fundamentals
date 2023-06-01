using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShopDemo.Core.Migrations
{
    public partial class SeedDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "IsActive", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("2db2cdca-f8a5-49e6-bc82-30ac7a7e723f"), true, "Eggs", 3.5m, 60 },
                    { new Guid("6ad9a2a8-3f86-4245-b438-04e366cbc2cc"), true, "Beer", 1.5m, 200 },
                    { new Guid("7c98ab25-e48c-4c18-8226-9e51abb31018"), true, "Ham", 10.45m, 40 },
                    { new Guid("abf33c8e-f3aa-4858-b32a-e0a68544e21f"), true, "Bread", 2m, 100 },
                    { new Guid("dc427471-daa0-4d70-9b71-2aa3e16558f9"), true, "Milk", 2.35m, 35 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: new Guid("2db2cdca-f8a5-49e6-bc82-30ac7a7e723f"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: new Guid("6ad9a2a8-3f86-4245-b438-04e366cbc2cc"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: new Guid("7c98ab25-e48c-4c18-8226-9e51abb31018"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: new Guid("abf33c8e-f3aa-4858-b32a-e0a68544e21f"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: new Guid("dc427471-daa0-4d70-9b71-2aa3e16558f9"));
        }
    }
}
