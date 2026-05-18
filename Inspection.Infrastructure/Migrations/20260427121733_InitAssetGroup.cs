using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitAssetGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetGroup",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    AssetCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    GroupCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsLeaf = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetGroup_AssetCategory_AssetCategoryId",
                        column: x => x.AssetCategoryId,
                        principalSchema: "Accounting",
                        principalTable: "AssetCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetGroup_AssetCategoryId",
                schema: "Accounting",
                table: "AssetGroup",
                column: "AssetCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetGroup_Tenant_ID_CompanyId_GroupCode_AssetCategoryId",
                schema: "Accounting",
                table: "AssetGroup",
                columns: new[] { "Tenant_ID", "CompanyId", "GroupCode", "AssetCategoryId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetGroup",
                schema: "Accounting");
        }
    }
}
