using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inleveropdracht_B2C2_WithAuthentication.Data.Migrations
{
    public partial class AddCameraToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Camera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gebruiker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plaats = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Omschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camera", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Camera");
        }
    }
}
