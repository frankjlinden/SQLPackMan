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
                name: "DbObjType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SqlType = table.Column<string>(maxLength: 50, nullable: true),
                    RGType = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbObjType", x => x.Id);
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
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(maxLength: 50, nullable: true),
                    IsItemLevel = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    StatusId = table.Column<int>(nullable: false, defaultValue: 1),
                    StatusDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    CurEnvironmentId = table.Column<int>(nullable: false, defaultValue: 1),
                    DbName = table.Column<string>(maxLength: 50, nullable: true),
                    MaxEnvironmentId = table.Column<int>(nullable: false, defaultValue: 1),
                    Version = table.Column<int>(nullable: false, defaultValue: 1),
                    Notes = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Package_DdsEnvironment_CurEnvironmentId",
                        column: x => x.CurEnvironmentId,
                        principalTable: "DdsEnvironment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Package_DdsEnvironment_MaxEnvironmentId",
                        column: x => x.MaxEnvironmentId,
                        principalTable: "DdsEnvironment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Package_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DbObject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ObjectName = table.Column<string>(maxLength: 150, nullable: true),
                    PackageId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false, defaultValue: 1),
                    StatusId = table.Column<int>(nullable: false, defaultValue: 1),
                    DbObjectTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbObject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbObject_DbObjType_DbObjectTypeId",
                        column: x => x.DbObjectTypeId,
                        principalTable: "DbObjType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DbObject_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DbObject_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Migration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Migration_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbObject_DbObjectTypeId",
                table: "DbObject",
                column: "DbObjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbObject_PackageId",
                table: "DbObject",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbObject_StatusId",
                table: "DbObject",
                column: "StatusId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Package_Name",
                table: "Package",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Package_StatusId",
                table: "Package",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbObject");

            migrationBuilder.DropTable(
                name: "MigrationResult");

            migrationBuilder.DropTable(
                name: "DbObjType");

            migrationBuilder.DropTable(
                name: "Migration");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "DdsEnvironment");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
