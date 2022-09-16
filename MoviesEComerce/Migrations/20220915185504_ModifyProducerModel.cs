using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesEComerce.Migrations
{
    public partial class ModifyProducerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProducerId",
                table: "Producer",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Producer",
                newName: "ProducerId");
        }
    }
}
