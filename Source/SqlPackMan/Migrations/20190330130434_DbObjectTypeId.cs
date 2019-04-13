using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlPackMan.Migrations
{
    public partial class DbObjectTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbObject_DbObjType_DbObjectTypeId",
                table: "DbObject");

            migrationBuilder.DropColumn(
                name: "ItemTypeId",
                table: "DbObject");

            migrationBuilder.AlterColumn<int>(
                name: "DbObjectTypeId",
                table: "DbObject",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DbObject_DbObjType_DbObjectTypeId",
                table: "DbObject",
                column: "DbObjectTypeId",
                principalTable: "DbObjType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbObject_DbObjType_DbObjectTypeId",
                table: "DbObject");

            migrationBuilder.AlterColumn<int>(
                name: "DbObjectTypeId",
                table: "DbObject",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ItemTypeId",
                table: "DbObject",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DbObject_DbObjType_DbObjectTypeId",
                table: "DbObject",
                column: "DbObjectTypeId",
                principalTable: "DbObjType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
