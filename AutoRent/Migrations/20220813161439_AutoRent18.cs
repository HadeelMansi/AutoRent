using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoRent.Migrations
{
    public partial class AutoRent18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "identityRoleId",
                table: "ApplicationRole",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRole_identityRoleId",
                table: "ApplicationRole",
                column: "identityRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRole_AspNetRoles_identityRoleId",
                table: "ApplicationRole",
                column: "identityRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRole_AspNetRoles_identityRoleId",
                table: "ApplicationRole");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationRole_identityRoleId",
                table: "ApplicationRole");

            migrationBuilder.DropColumn(
                name: "identityRoleId",
                table: "ApplicationRole");
        }
    }
}
