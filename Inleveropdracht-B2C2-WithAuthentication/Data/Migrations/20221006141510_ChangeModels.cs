using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inleveropdracht_B2C2_WithAuthentication.Data.Migrations
{
    public partial class ChangeModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cameras_AspNetUsers_AppUserId",
                table: "Cameras");

            migrationBuilder.AddForeignKey(
                name: "FK_Cameras_AspNetUsers_AppUserId",
                table: "Cameras",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cameras_AspNetUsers_AppUserId",
                table: "Cameras");

            migrationBuilder.AddForeignKey(
                name: "FK_Cameras_AspNetUsers_AppUserId",
                table: "Cameras",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
