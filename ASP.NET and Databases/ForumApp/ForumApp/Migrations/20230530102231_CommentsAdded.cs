using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ForumApp.Migrations
{
    /// <inheritdoc />
    public partial class CommentsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "posts",
                comment: "Published posts");

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "id", "content", "title" },
                values: new object[,]
                {
                    { 1, "My first post will be about performing CRUD operations in MVC. It's so much fun!", "My first post" },
                    { 2, "This is my second post. CRUD operations in MVC are getting more and more interesting!", "My second post" },
                    { 3, "Hello there! I'm getting better and better with CRUD operations in MVC. Stay tuned!", "My third post" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.AlterTable(
                name: "posts",
                oldComment: "Published posts");
        }
    }
}
