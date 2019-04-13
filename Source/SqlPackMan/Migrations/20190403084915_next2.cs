using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlPackMan.Migrations
{
    public partial class next2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Package",
                maxLength: 50,
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusDate",
                table: "Package",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "CurEnvironmentId",
                table: "Package",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldDefaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Package",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 50,
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusDate",
                table: "Package",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<int>(
                name: "CurEnvironmentId",
                table: "Package",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldDefaultValue: 1);
        }
    }
}
