using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inleveropdracht_B2C2_WithAuthentication.Data.Migrations
{
    public partial class ChangeTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Puntens",
                table: "Puntens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Camera",
                table: "Camera");

            migrationBuilder.RenameTable(
                name: "Puntens",
                newName: "Points");

            migrationBuilder.RenameTable(
                name: "Camera",
                newName: "Cameras");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Points",
                table: "Points",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cameras",
                table: "Cameras",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Points",
                table: "Points");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cameras",
                table: "Cameras");

            migrationBuilder.RenameTable(
                name: "Points",
                newName: "Puntens");

            migrationBuilder.RenameTable(
                name: "Cameras",
                newName: "Camera");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Puntens",
                table: "Puntens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Camera",
                table: "Camera",
                column: "Id");
        }
    }
}
