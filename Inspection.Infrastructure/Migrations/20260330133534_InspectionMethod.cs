using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InspectionMethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UX_InspectionMethod_InsMethodNo_Tenant",
                schema: "Inspection",
                table: "InspectionMethod");

            migrationBuilder.DropColumn(
                name: "InsMethodNo",
                schema: "Inspection",
                table: "InspectionMethod");

            migrationBuilder.DropColumn(
                name: "series",
                schema: "Inspection",
                table: "InspectionMethod");

            migrationBuilder.AlterColumn<string>(
                name: "Tenant_ID",
                schema: "Inspection",
                table: "InspectionMethod",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Inspection",
                table: "InspectionMethod",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "Inspection",
                table: "InspectionMethod",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                schema: "Inspection",
                table: "InspectionMethod",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "In_Date",
                schema: "Inspection",
                table: "InspectionMethod",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "In_User",
                schema: "Inspection",
                table: "InspectionMethod",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Mod_Date",
                schema: "Inspection",
                table: "InspectionMethod",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mod_User",
                schema: "Inspection",
                table: "InspectionMethod",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RunningNumber",
                schema: "Inspection",
                table: "InspectionMethod",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "SeriesId",
                schema: "Inspection",
                table: "InspectionMethod",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionMethod_SeriesId",
                schema: "Inspection",
                table: "InspectionMethod",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionMethod_Tenant_ID_CompanyId_Code",
                schema: "Inspection",
                table: "InspectionMethod",
                columns: new[] { "Tenant_ID", "CompanyId", "Code" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionMethod_Series_SeriesId",
                schema: "Inspection",
                table: "InspectionMethod",
                column: "SeriesId",
                principalSchema: "Stt",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionMethod_Series_SeriesId",
                schema: "Inspection",
                table: "InspectionMethod");

            migrationBuilder.DropIndex(
                name: "IX_InspectionMethod_SeriesId",
                schema: "Inspection",
                table: "InspectionMethod");

            migrationBuilder.DropIndex(
                name: "IX_InspectionMethod_Tenant_ID_CompanyId_Code",
                schema: "Inspection",
                table: "InspectionMethod");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "Inspection",
                table: "InspectionMethod");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "Inspection",
                table: "InspectionMethod");

            migrationBuilder.DropColumn(
                name: "In_Date",
                schema: "Inspection",
                table: "InspectionMethod");

            migrationBuilder.DropColumn(
                name: "In_User",
                schema: "Inspection",
                table: "InspectionMethod");

            migrationBuilder.DropColumn(
                name: "Mod_Date",
                schema: "Inspection",
                table: "InspectionMethod");

            migrationBuilder.DropColumn(
                name: "Mod_User",
                schema: "Inspection",
                table: "InspectionMethod");

            migrationBuilder.DropColumn(
                name: "RunningNumber",
                schema: "Inspection",
                table: "InspectionMethod");

            migrationBuilder.DropColumn(
                name: "SeriesId",
                schema: "Inspection",
                table: "InspectionMethod");

            migrationBuilder.AlterColumn<string>(
                name: "Tenant_ID",
                schema: "Inspection",
                table: "InspectionMethod",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Inspection",
                table: "InspectionMethod",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "InsMethodNo",
                schema: "Inspection",
                table: "InspectionMethod",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "series",
                schema: "Inspection",
                table: "InspectionMethod",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "UX_InspectionMethod_InsMethodNo_Tenant",
                schema: "Inspection",
                table: "InspectionMethod",
                columns: new[] { "InsMethodNo", "Tenant_ID" },
                unique: true);
        }
    }
}
