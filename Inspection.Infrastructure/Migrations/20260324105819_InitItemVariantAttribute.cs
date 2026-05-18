using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitItemVariantAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemVariantAttribute",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    AttributeId = table.Column<long>(type: "bigint", nullable: false),
                    ItemAttributeValueId = table.Column<long>(type: "bigint", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ItemId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVariantAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemVariantAttribute_ItemAttributeValue_ItemAttributeValueId",
                        column: x => x.ItemAttributeValueId,
                        principalSchema: "Inventory",
                        principalTable: "ItemAttributeValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemVariantAttribute_ItemAttribute_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "Inventory",
                        principalTable: "ItemAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemVariantAttribute_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemVariantAttribute_Item_ItemId1",
                        column: x => x.ItemId1,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemVariantAttribute_AttributeId",
                schema: "Inventory",
                table: "ItemVariantAttribute",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVariantAttribute_ItemAttributeValueId",
                schema: "Inventory",
                table: "ItemVariantAttribute",
                column: "ItemAttributeValueId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVariantAttribute_ItemId1",
                schema: "Inventory",
                table: "ItemVariantAttribute",
                column: "ItemId1");

            migrationBuilder.CreateIndex(
                name: "UQ_ItemVariantAttribute",
                schema: "Inventory",
                table: "ItemVariantAttribute",
                columns: new[] { "ItemId", "AttributeId", "ItemAttributeValueId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemVariantAttribute",
                schema: "Inventory");
        }
    }
}
