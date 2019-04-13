using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlPackMan.Migrations
{
    public partial class version : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemVersion",
                table: "DbObject",
                newName: "Version");

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                table: "Package",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Package_MaxEnvironmentId",
                table: "Package",
                column: "MaxEnvironmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Package_DdsEnvironment_MaxEnvironmentId",
                table: "Package",
                column: "MaxEnvironmentId",
                principalTable: "DdsEnvironment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Package_DdsEnvironment_MaxEnvironmentId",
                table: "Package");

            migrationBuilder.DropIndex(
                name: "IX_Package_MaxEnvironmentId",
                table: "Package");

            migrationBuilder.RenameColumn(
                name: "Version",
                table: "DbObject",
                newName: "ItemVersion");

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                table: "Package",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 1);
        }
    }
}
