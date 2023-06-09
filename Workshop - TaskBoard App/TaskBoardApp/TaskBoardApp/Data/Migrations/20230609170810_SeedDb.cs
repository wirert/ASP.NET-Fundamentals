using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Open" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "In Progress" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Done" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 11, 21, 20, 8, 10, 190, DateTimeKind.Local).AddTicks(3742), "Implement better styling for all public pages", "2bd4cb6d-b8bd-440f-a8f0-f84b8ec225ef", "Improve CSS styles" },
                    { 2, 1, new DateTime(2023, 6, 4, 20, 8, 10, 190, DateTimeKind.Local).AddTicks(3776), "Create Android client app for the TaskBoard RESTful API", "2bd4cb6d-b8bd-440f-a8f0-f84b8ec225ef", "Android Client App" },
                    { 3, 2, new DateTime(2023, 5, 9, 20, 8, 10, 190, DateTimeKind.Local).AddTicks(3780), "Create Windows Forms desktop app client for the TaskBoard RESTful API", "b5731c65-0597-45ab-a4ff-55b8eac87aac", "Desktop Client App" },
                    { 4, 3, new DateTime(2022, 6, 9, 20, 8, 10, 190, DateTimeKind.Local).AddTicks(3783), "Implement [Create Task] page for adding new tasks", "b5731c65-0597-45ab-a4ff-55b8eac87aac", "Create Tasks" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
