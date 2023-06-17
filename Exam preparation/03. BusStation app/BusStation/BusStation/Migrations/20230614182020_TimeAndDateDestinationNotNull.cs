using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusStation.Migrations
{
    public partial class TimeAndDateDestinationNotNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "Destinations",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "Destination time",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true,
                oldComment: "Destination time");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Destinations",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "Destination date",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true,
                oldComment: "Destination date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "Destinations",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                comment: "Destination time",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "Destination time");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Destinations",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                comment: "Destination date",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "Destination date");
        }
    }
}
