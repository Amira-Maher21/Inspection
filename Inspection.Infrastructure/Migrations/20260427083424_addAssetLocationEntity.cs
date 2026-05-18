using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addAssetLocationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetLocation",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParentLocationId = table.Column<long>(type: "bigint", nullable: true),
                    LocationCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsLeaf = table.Column<bool>(type: "bit", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetLocation_AssetLocation_ParentLocationId",
                        column: x => x.ParentLocationId,
                        principalSchema: "Accounting",
                        principalTable: "AssetLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetLocation_ParentLocationId",
                schema: "Accounting",
                table: "AssetLocation",
                column: "ParentLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLocation_Tenant_ID_CompanyId_LocationCode",
                schema: "Accounting",
                table: "AssetLocation",
                columns: new[] { "Tenant_ID", "CompanyId", "LocationCode" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetLocation",
                schema: "Accounting");
        }
    }
}
