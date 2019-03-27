using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlPackMan.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DdsEnvironment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Server = table.Column<string>(nullable: true),
                    SourceControlPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DdsEnvironment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    StatusDate = table.Column<DateTime>(nullable: false),
                    DdsEnvironmentId = table.Column<int>(nullable: false, defaultValue: 0),
                    DbName = table.Column<string>(nullable: true),
                    MaxEnvironmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbObject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ObjectName = table.Column<string>(nullable: true),
                    PackageId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    ItemTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbObject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbObject_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Migration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    PackageId = table.Column<int>(nullable: false),
                    PreScript = table.Column<string>(nullable: true),
                    PostScript = table.Column<string>(nullable: true),
                    PackageScript = table.Column<string>(nullable: true),
                    DdsEnvironmentId = table.Column<int>(nullable: false),
                    TargetEnvironment = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Migration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Migration_DdsEnvironment_DdsEnvironmentId",
                        column: x => x.DdsEnvironmentId,
                        principalTable: "DdsEnvironment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Migration_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MigrationResult",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MigrationId = table.Column<int>(nullable: false),
                    Step = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    ResultText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MigrationResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MigrationResult_Migration_MigrationId",
                        column: x => x.MigrationId,
                        principalTable: "Migration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbObject_PackageId",
                table: "DbObject",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_DdsEnvironment_Name",
                table: "DdsEnvironment",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Migration_DdsEnvironmentId",
                table: "Migration",
                column: "DdsEnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Migration_PackageId",
                table: "Migration",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_MigrationResult_MigrationId",
                table: "MigrationResult",
                column: "MigrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_Name",
                table: "Package",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbObject");

            migrationBuilder.DropTable(
                name: "MigrationResult");

            migrationBuilder.DropTable(
                name: "Migration");

            migrationBuilder.DropTable(
                name: "DdsEnvironment");

            migrationBuilder.DropTable(
                name: "Package");
        }
    }
}
