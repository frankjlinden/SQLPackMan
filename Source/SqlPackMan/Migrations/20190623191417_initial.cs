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
                name: "DbObjectName",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbObjectName", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "DdsEnvironment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Server = table.Column<string>(maxLength: 50, nullable: true),
                    SchemaPath = table.Column<string>(maxLength: 150, nullable: true)
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
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    StatusDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    CurEnvironmentId = table.Column<int>(nullable: false, defaultValue: 1),
                    DbName = table.Column<string>(maxLength: 50, nullable: false),
                    MaxEnvironmentId = table.Column<int>(nullable: false, defaultValue: 1),
                    Version = table.Column<int>(nullable: false, defaultValue: 1),
                    Notes = table.Column<string>(maxLength: 1000, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                    table.UniqueConstraint("AK_Package_DbName_Name", x => new { x.DbName, x.Name });
                    table.ForeignKey(
                        name: "FK_Package_DdsEnvironment_CurEnvironmentId",
                        column: x => x.CurEnvironmentId,
                        principalTable: "DdsEnvironment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Package_DdsEnvironment_MaxEnvironmentId",
                        column: x => x.MaxEnvironmentId,
                        principalTable: "DdsEnvironment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbObject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ObjectName = table.Column<string>(maxLength: 150, nullable: true),
                    TagString = table.Column<string>(maxLength: 1024, nullable: true),
                    PackageId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false, defaultValue: 1),
                    StatusDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DbObjectType = table.Column<int>(nullable: false)
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
                    Status = table.Column<int>(nullable: false),
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
                    Step = table.Column<string>(maxLength: 50, nullable: true),
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
                name: "IX_Package_CurEnvironmentId",
                table: "Package",
                column: "CurEnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_MaxEnvironmentId",
                table: "Package",
                column: "MaxEnvironmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbObject");

            migrationBuilder.DropTable(
                name: "DbObjectName");

            migrationBuilder.DropTable(
                name: "MigrationResult");

            migrationBuilder.DropTable(
                name: "Migration");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "DdsEnvironment");
        }
    }
}
