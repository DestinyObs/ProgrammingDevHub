using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingDevHub.Migrations
{
    public partial class NewUpdatedAppUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GitHubName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PhonNumber",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GitHubName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhonNumber",
                table: "AspNetUsers");
        }
    }
}
