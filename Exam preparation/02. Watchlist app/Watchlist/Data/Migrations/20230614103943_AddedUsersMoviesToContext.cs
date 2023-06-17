using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Watchlist.Data.Migrations
{
    public partial class AddedUsersMoviesToContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovie_AspNetUsers_UserId",
                table: "UserMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMovie_Movies_MovieId",
                table: "UserMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMovie",
                table: "UserMovie");

            migrationBuilder.RenameTable(
                name: "UserMovie",
                newName: "UsersMovies");

            migrationBuilder.RenameIndex(
                name: "IX_UserMovie_UserId",
                table: "UsersMovies",
                newName: "IX_UsersMovies_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersMovies",
                table: "UsersMovies",
                columns: new[] { "MovieId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersMovies_AspNetUsers_UserId",
                table: "UsersMovies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersMovies_Movies_MovieId",
                table: "UsersMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersMovies_AspNetUsers_UserId",
                table: "UsersMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersMovies_Movies_MovieId",
                table: "UsersMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersMovies",
                table: "UsersMovies");

            migrationBuilder.RenameTable(
                name: "UsersMovies",
                newName: "UserMovie");

            migrationBuilder.RenameIndex(
                name: "IX_UsersMovies_UserId",
                table: "UserMovie",
                newName: "IX_UserMovie_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMovie",
                table: "UserMovie",
                columns: new[] { "MovieId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovie_AspNetUsers_UserId",
                table: "UserMovie",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovie_Movies_MovieId",
                table: "UserMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
