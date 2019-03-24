using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlPackMan.Migrations
{
    public partial class PackageStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Migration_DdsEnvironment_DdsEnvironmentID",
                table: "Migration");

            migrationBuilder.RenameColumn(
                name: "DdsEnvironmentID",
                table: "Migration",
                newName: "SourceEnvironmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Migration_DdsEnvironmentID",
                table: "Migration",
                newName: "IX_Migration_SourceEnvironmentID");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "PackageItem",
                type: "nvarchar(24)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Migration_DdsEnvironment_SourceEnvironmentID",
                table: "Migration",
                column: "SourceEnvironmentID",
                principalTable: "DdsEnvironment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Migration_DdsEnvironment_SourceEnvironmentID",
                table: "Migration");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PackageItem");

            migrationBuilder.RenameColumn(
                name: "SourceEnvironmentID",
                table: "Migration",
                newName: "DdsEnvironmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Migration_SourceEnvironmentID",
                table: "Migration",
                newName: "IX_Migration_DdsEnvironmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Migration_DdsEnvironment_DdsEnvironmentID",
                table: "Migration",
                column: "DdsEnvironmentID",
                principalTable: "DdsEnvironment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
