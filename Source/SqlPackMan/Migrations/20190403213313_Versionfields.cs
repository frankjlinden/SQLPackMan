using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlPackMan.Migrations
{
    public partial class Versionfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FeatureVersion",
                table: "Package",
                newName: "Version");

            migrationBuilder.AddColumn<int>(
                name: "ItemVersion",
                table: "DbObject",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemVersion",
                table: "DbObject");

            migrationBuilder.RenameColumn(
                name: "Version",
                table: "Package",
                newName: "FeatureVersion");
        }
    }
}
