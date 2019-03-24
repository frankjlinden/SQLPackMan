using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlPackMan.Migrations
{
    public partial class DDSENV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TargetEnv",
                table: "DdsEnvironment",
                type: "nvarchar(24)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "SourceEnv",
                table: "DdsEnvironment",
                type: "nvarchar(24)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_PackageItem_PackageId",
                table: "PackageItem",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageItem_Package_PackageId",
                table: "PackageItem",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageItem_Package_PackageId",
                table: "PackageItem");

            migrationBuilder.DropIndex(
                name: "IX_PackageItem_PackageId",
                table: "PackageItem");

            migrationBuilder.AlterColumn<int>(
                name: "TargetEnv",
                table: "DdsEnvironment",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)");

            migrationBuilder.AlterColumn<int>(
                name: "SourceEnv",
                table: "DdsEnvironment",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)");
        }
    }
}
