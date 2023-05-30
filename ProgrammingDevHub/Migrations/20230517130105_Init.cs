using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingDevHub.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_groups_AspNetUsers_AppUserId",
                table: "groups");

            migrationBuilder.DropForeignKey(
                name: "FK_groups_Language_LangId",
                table: "groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_groups",
                table: "groups");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Language");

            migrationBuilder.RenameTable(
                name: "groups",
                newName: "Clubs");

            migrationBuilder.RenameIndex(
                name: "IX_groups_LangId",
                table: "Clubs",
                newName: "IX_Clubs_LangId");

            migrationBuilder.RenameIndex(
                name: "IX_groups_AppUserId",
                table: "Clubs",
                newName: "IX_Clubs_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clubs",
                table: "Clubs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_AspNetUsers_AppUserId",
                table: "Clubs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Language_LangId",
                table: "Clubs",
                column: "LangId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_AspNetUsers_AppUserId",
                table: "Clubs");

            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Language_LangId",
                table: "Clubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clubs",
                table: "Clubs");

            migrationBuilder.RenameTable(
                name: "Clubs",
                newName: "groups");

            migrationBuilder.RenameIndex(
                name: "IX_Clubs_LangId",
                table: "groups",
                newName: "IX_groups_LangId");

            migrationBuilder.RenameIndex(
                name: "IX_Clubs_AppUserId",
                table: "groups",
                newName: "IX_groups_AppUserId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Language",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_groups",
                table: "groups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_groups_AspNetUsers_AppUserId",
                table: "groups",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_groups_Language_LangId",
                table: "groups",
                column: "LangId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
