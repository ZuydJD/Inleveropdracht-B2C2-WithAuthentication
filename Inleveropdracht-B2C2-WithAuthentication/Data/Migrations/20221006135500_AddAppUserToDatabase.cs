using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inleveropdracht_B2C2_WithAuthentication.Data.Migrations
{
    public partial class AddAppUserToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Cameras",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Achternaam",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Naam",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Punten",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_AppUserId",
                table: "Cameras",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cameras_AspNetUsers_AppUserId",
                table: "Cameras",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cameras_AspNetUsers_AppUserId",
                table: "Cameras");

            migrationBuilder.DropIndex(
                name: "IX_Cameras_AppUserId",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "Achternaam",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Naam",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Punten",
                table: "AspNetUsers");
        }
    }
}
