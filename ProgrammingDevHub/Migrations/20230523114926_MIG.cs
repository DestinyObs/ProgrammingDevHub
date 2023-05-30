using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingDevHub.Migrations
{
    public partial class MIG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Language_LangId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "LangId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Language_LangId",
                table: "AspNetUsers",
                column: "LangId",
                principalTable: "Language",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Language_LangId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "LangId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Language_LangId",
                table: "AspNetUsers",
                column: "LangId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
