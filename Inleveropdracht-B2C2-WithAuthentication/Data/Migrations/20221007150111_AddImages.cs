using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inleveropdracht_B2C2_WithAuthentication.Data.Migrations
{
    public partial class AddImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CameraImageUrl",
                table: "Cameras",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CameraImageUrl",
                table: "Cameras");
        }
    }
}
