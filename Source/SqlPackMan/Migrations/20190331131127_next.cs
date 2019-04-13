using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlPackMan.Migrations
{
    public partial class next : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Package");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Package",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Package_StatusId",
                table: "Package",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Package_Status_StatusId",
                table: "Package",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Package_Status_StatusId",
                table: "Package");

            migrationBuilder.DropIndex(
                name: "IX_Package_StatusId",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Package");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Package",
                maxLength: 50,
                nullable: true);
        }
    }
}
