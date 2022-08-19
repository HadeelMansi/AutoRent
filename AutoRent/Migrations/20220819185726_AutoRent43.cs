using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoRent.Migrations
{
    public partial class AutoRent43 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CarImages",
                table: "CarImages");

            migrationBuilder.DropColumn(
                name: "CarImageId",
                table: "CarImages");

            migrationBuilder.AddColumn<int>(
                name: "CarImgeId",
                table: "CarImages",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "CarImg",
                table: "CarImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarImages",
                table: "CarImages",
                column: "CarImgeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CarImages",
                table: "CarImages");

            migrationBuilder.DropColumn(
                name: "CarImgeId",
                table: "CarImages");

            migrationBuilder.DropColumn(
                name: "CarImg",
                table: "CarImages");

            migrationBuilder.AddColumn<Guid>(
                name: "CarImageId",
                table: "CarImages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarImages",
                table: "CarImages",
                column: "CarImageId");
        }
    }
}
