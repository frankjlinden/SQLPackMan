using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlPackMan.Migrations
{
    public partial class dbObjectTypeNavProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DdsEnvironmentId",
                table: "Package",
                newName: "CurEnvironmentId");

            migrationBuilder.AddColumn<int>(
                name: "DbObjectTypeId",
                table: "DbObject",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Package_CurEnvironmentId",
                table: "Package",
                column: "CurEnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DbObject_DbObjectTypeId",
                table: "DbObject",
                column: "DbObjectTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbObject_DbObjType_DbObjectTypeId",
                table: "DbObject",
                column: "DbObjectTypeId",
                principalTable: "DbObjType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Package_DdsEnvironment_CurEnvironmentId",
                table: "Package",
                column: "CurEnvironmentId",
                principalTable: "DdsEnvironment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbObject_DbObjType_DbObjectTypeId",
                table: "DbObject");

            migrationBuilder.DropForeignKey(
                name: "FK_Package_DdsEnvironment_CurEnvironmentId",
                table: "Package");

            migrationBuilder.DropIndex(
                name: "IX_Package_CurEnvironmentId",
                table: "Package");

            migrationBuilder.DropIndex(
                name: "IX_DbObject_DbObjectTypeId",
                table: "DbObject");

            migrationBuilder.DropColumn(
                name: "DbObjectTypeId",
                table: "DbObject");

            migrationBuilder.RenameColumn(
                name: "CurEnvironmentId",
                table: "Package",
                newName: "DdsEnvironmentId");
        }
    }
}
