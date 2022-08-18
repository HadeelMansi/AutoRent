using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoRent.Migrations
{
    public partial class AutoRent17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentRoleId",
                table: "ApplicationRole",
                newName: "RoleId");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationRoleName",
                table: "ApplicationRole",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationRoleName",
                table: "ApplicationRole");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "ApplicationRole",
                newName: "ParentRoleId");
        }
    }
}
