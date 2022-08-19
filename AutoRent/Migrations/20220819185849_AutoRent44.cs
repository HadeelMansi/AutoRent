using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoRent.Migrations
{
    public partial class AutoRent44 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarImgeId",
                table: "CarImages",
                newName: "CarImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarImageId",
                table: "CarImages",
                newName: "CarImgeId");
        }
    }
}
