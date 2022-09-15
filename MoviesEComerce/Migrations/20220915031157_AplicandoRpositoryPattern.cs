using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesEComerce.Migrations
{
    public partial class AplicandoRpositoryPattern : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActorId",
                table: "Actor",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Actor",
                newName: "ActorId");
        }
    }
}
