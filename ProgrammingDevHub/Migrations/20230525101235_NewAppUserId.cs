using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingDevHub.Migrations
{
    public partial class NewAppUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetUps_AspNetUsers_UserId",
                table: "MeetUps");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "MeetUps",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_MeetUps_UserId",
                table: "MeetUps",
                newName: "IX_MeetUps_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetUps_AspNetUsers_AppUserId",
                table: "MeetUps",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetUps_AspNetUsers_AppUserId",
                table: "MeetUps");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "MeetUps",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MeetUps_AppUserId",
                table: "MeetUps",
                newName: "IX_MeetUps_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetUps_AspNetUsers_UserId",
                table: "MeetUps",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
