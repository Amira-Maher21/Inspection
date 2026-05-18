using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateAssetCustody : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateIndex(
                name: "IX_AssetCustodyLine_FixedAssetId",
                schema: "Accounting",
                table: "AssetCustodyLine",
                column: "FixedAssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetCustodyLine_FixedAsset_FixedAssetId",
                schema: "Accounting",
                table: "AssetCustodyLine",
                column: "FixedAssetId",
                principalSchema: "Accounting",
                principalTable: "FixedAsset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetCustodyLine_FixedAsset_FixedAssetId",
                schema: "Accounting",
                table: "AssetCustodyLine");

            migrationBuilder.DropIndex(
                name: "IX_AssetCustodyLine_FixedAssetId",
                schema: "Accounting",
                table: "AssetCustodyLine");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                schema: "Manufacturing",
                table: "ProductionOrder",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
