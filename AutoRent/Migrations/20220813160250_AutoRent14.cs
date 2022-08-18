using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoRent.Migrations
{
    public partial class AutoRent14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "ApplicationRole",
                newName: "ParentRoleId");

            migrationBuilder.AddColumn<int>(
                name: "OrderNo",
                table: "ApplicationRole",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RoleImg",
                table: "ApplicationRole",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNo",
                table: "ApplicationRole");

            migrationBuilder.DropColumn(
                name: "RoleImg",
                table: "ApplicationRole");

            migrationBuilder.RenameColumn(
                name: "ParentRoleId",
                table: "ApplicationRole",
                newName: "RoleId");
        }
    }
}
