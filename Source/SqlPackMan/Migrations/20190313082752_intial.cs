using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlPackMan.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DDSEnvironment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Connection = table.Column<string>(nullable: true),
                    SourceDb = table.Column<int>(nullable: false),
                    TargetDb = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDSEnvironment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DDSEnvironmentId = table.Column<int>(nullable: false),
                    Database = table.Column<string>(type: "nvarchar(24)", nullable: false),
                    MaxEnvironment = table.Column<int>(nullable: false),
                    PackageStatus = table.Column<string>(type: "nvarchar(24)", nullable: false),
                    StatusDate = table.Column<DateTime>(nullable: false),
                    ScriptPre = table.Column<string>(nullable: true),
                    ScriptPost = table.Column<string>(nullable: true),
                    ScriptItems = table.Column<string>(nullable: true),
                    StepNumber = table.Column<int>(nullable: false),
                    Version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PackageItem",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PackageId = table.Column<int>(nullable: false),
                    DbObjectName = table.Column<string>(nullable: true),
                    DbObjectType = table.Column<string>(type: "nvarchar(24)", nullable: false),
                    StepNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageItem", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Migration",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    ResultText = table.Column<string>(nullable: true),
                    Status = table.Column<string>(type: "nvarchar(24)", nullable: false),
                    Database = table.Column<int>(nullable: false),
                    DDSEnvironmentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Migration", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Migration_DDSEnvironment_DDSEnvironmentID",
                        column: x => x.DDSEnvironmentID,
                        principalTable: "DDSEnvironment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Migration_DDSEnvironmentID",
                table: "Migration",
                column: "DDSEnvironmentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Migration");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "PackageItem");

            migrationBuilder.DropTable(
                name: "DDSEnvironment");
        }
    }
}
