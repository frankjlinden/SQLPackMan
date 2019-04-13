using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlPackMan.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "DbObject");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "DbObject",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DbObject_StatusId",
                table: "DbObject",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbObject_Status_StatusId",
                table: "DbObject",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbObject_Status_StatusId",
                table: "DbObject");

            migrationBuilder.DropIndex(
                name: "IX_DbObject_StatusId",
                table: "DbObject");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "DbObject");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "DbObject",
                maxLength: 50,
                nullable: true);
        }
    }
}
