using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesEComerce.Migrations
{
    public partial class ModifyCinemaModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CinemaId",
                table: "Cinema",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cinema",
                newName: "CinemaId");
        }
    }
}
