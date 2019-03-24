using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlPackMan.Migrations
{
    public partial class newnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Migration_DDSEnvironment_SourceEnvironmentID",
                table: "Migration");

            migrationBuilder.DropIndex(
                name: "IX_Migration_SourceEnvironmentID",
                table: "Migration");

            migrationBuilder.DropColumn(
                name: "SourceEnvironmentID",
                table: "Migration");

            migrationBuilder.RenameColumn(
                name: "Database",
                table: "Migration",
                newName: "DDSDatabaseId");

            migrationBuilder.AlterColumn<int>(
                name: "MaxEnvironment",
                table: "Package",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)");

            migrationBuilder.AddColumn<string>(
                name: "MyProperty",
                table: "Migration",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Migration",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TargetEnv",
                table: "DDSEnvironment",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)");

            migrationBuilder.AlterColumn<int>(
                name: "SourceEnv",
                table: "DDSEnvironment",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)");

            migrationBuilder.CreateTable(
                name: "DDSDatabase",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDSDatabase", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Package_DDSEnvironmentId",
                table: "Package",
                column: "DDSEnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Migration_DDSDatabaseId",
                table: "Migration",
                column: "DDSDatabaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Migration_DDSDatabase_DDSDatabaseId",
                table: "Migration",
                column: "DDSDatabaseId",
                principalTable: "DDSDatabase",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Package_DDSEnvironment_DDSEnvironmentId",
                table: "Package",
                column: "DDSEnvironmentId",
                principalTable: "DDSEnvironment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Migration_DDSDatabase_DDSDatabaseId",
                table: "Migration");

            migrationBuilder.DropForeignKey(
                name: "FK_Package_DDSEnvironment_DDSEnvironmentId",
                table: "Package");

            migrationBuilder.DropTable(
                name: "DDSDatabase");

            migrationBuilder.DropIndex(
                name: "IX_Package_DDSEnvironmentId",
                table: "Package");

            migrationBuilder.DropIndex(
                name: "IX_Migration_DDSDatabaseId",
                table: "Migration");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Migration");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Migration");

            migrationBuilder.RenameColumn(
                name: "DDSDatabaseId",
                table: "Migration",
                newName: "Database");

            migrationBuilder.AlterColumn<string>(
                name: "MaxEnvironment",
                table: "Package",
                type: "nvarchar(24)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "SourceEnvironmentID",
                table: "Migration",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TargetEnv",
                table: "DDSEnvironment",
                type: "nvarchar(24)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "SourceEnv",
                table: "DDSEnvironment",
                type: "nvarchar(24)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Migration_SourceEnvironmentID",
                table: "Migration",
                column: "SourceEnvironmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Migration_DDSEnvironment_SourceEnvironmentID",
                table: "Migration",
                column: "SourceEnvironmentID",
                principalTable: "DDSEnvironment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
