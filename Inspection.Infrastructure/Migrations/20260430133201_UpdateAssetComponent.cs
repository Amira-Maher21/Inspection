using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAssetComponent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetComponent_FixedAsset_FixedAssetId",
                schema: "Accounting",
                table: "AssetComponent");


            migrationBuilder.AddForeignKey(
                name: "FK_AssetComponent_FixedAsset_FixedAssetId",
                schema: "Accounting",
                table: "AssetComponent",
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
                name: "FK_AssetComponent_FixedAsset_FixedAssetId",
                schema: "Accounting",
                table: "AssetComponent");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                schema: "Manufacturing",
                table: "ProductionOrder",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetComponent_FixedAsset_FixedAssetId",
                schema: "Accounting",
                table: "AssetComponent",
                column: "FixedAssetId",
                principalSchema: "Accounting",
                principalTable: "FixedAsset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
