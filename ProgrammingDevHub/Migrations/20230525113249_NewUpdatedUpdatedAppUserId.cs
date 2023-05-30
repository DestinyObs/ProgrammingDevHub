using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingDevHub.Migrations
{
    public partial class NewUpdatedUpdatedAppUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhonNumber",
                table: "AspNetUsers",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "AspNetUsers",
                newName: "State");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "AspNetUsers",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "AspNetUsers",
                newName: "PhonNumber");
        }
    }
}
