using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeliveryNoteLineFK7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionOrderLine_ProductionOrder_ProductionOrderId",
                schema: "Manufacturing",
                table: "ProductionOrderLine");

            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Sales",
                table: "DeliveryNoteLine",
                newName: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrderLine_CostCodeId",
                schema: "Manufacturing",
                table: "ProductionOrderLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrderLine_WBSId",
                schema: "Manufacturing",
                table: "ProductionOrderLine",
                column: "WBSId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNoteLine_ActivityId",
                schema: "Sales",
                table: "DeliveryNoteLine",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNoteLine_BOQLineId",
                schema: "Sales",
                table: "DeliveryNoteLine",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNoteLine_CostCodeId",
                schema: "Sales",
                table: "DeliveryNoteLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNoteLine_ProductionOrderId",
                schema: "Sales",
                table: "DeliveryNoteLine",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNoteLine_SubcontractBOQId",
                schema: "Sales",
                table: "DeliveryNoteLine",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNoteLine_WBSId",
                schema: "Sales",
                table: "DeliveryNoteLine",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNoteLine_Activity_ActivityId",
                schema: "Sales",
                table: "DeliveryNoteLine",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNoteLine_BOQLine_BOQLineId",
                schema: "Sales",
                table: "DeliveryNoteLine",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNoteLine_CostCode_CostCodeId",
                schema: "Sales",
                table: "DeliveryNoteLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNoteLine_ProductionOrder_ProductionOrderId",
                schema: "Sales",
                table: "DeliveryNoteLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNoteLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Sales",
                table: "DeliveryNoteLine",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNoteLine_WBS_WBSId",
                schema: "Sales",
                table: "DeliveryNoteLine",
                column: "WBSId",
                principalSchema: "Contracting",
                principalTable: "WBS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionOrderLine_CostCode_CostCodeId",
                schema: "Manufacturing",
                table: "ProductionOrderLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionOrderLine_ProductionOrder_ProductionOrderId",
                schema: "Manufacturing",
                table: "ProductionOrderLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionOrderLine_WBS_WBSId",
                schema: "Manufacturing",
                table: "ProductionOrderLine",
                column: "WBSId",
                principalSchema: "Contracting",
                principalTable: "WBS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNoteLine_Activity_ActivityId",
                schema: "Sales",
                table: "DeliveryNoteLine");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNoteLine_BOQLine_BOQLineId",
                schema: "Sales",
                table: "DeliveryNoteLine");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNoteLine_CostCode_CostCodeId",
                schema: "Sales",
                table: "DeliveryNoteLine");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNoteLine_ProductionOrder_ProductionOrderId",
                schema: "Sales",
                table: "DeliveryNoteLine");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNoteLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Sales",
                table: "DeliveryNoteLine");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNoteLine_WBS_WBSId",
                schema: "Sales",
                table: "DeliveryNoteLine");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionOrderLine_CostCode_CostCodeId",
                schema: "Manufacturing",
                table: "ProductionOrderLine");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionOrderLine_ProductionOrder_ProductionOrderId",
                schema: "Manufacturing",
                table: "ProductionOrderLine");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionOrderLine_WBS_WBSId",
                schema: "Manufacturing",
                table: "ProductionOrderLine");

            migrationBuilder.DropIndex(
                name: "IX_ProductionOrderLine_CostCodeId",
                schema: "Manufacturing",
                table: "ProductionOrderLine");

            migrationBuilder.DropIndex(
                name: "IX_ProductionOrderLine_WBSId",
                schema: "Manufacturing",
                table: "ProductionOrderLine");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryNoteLine_ActivityId",
                schema: "Sales",
                table: "DeliveryNoteLine");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryNoteLine_BOQLineId",
                schema: "Sales",
                table: "DeliveryNoteLine");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryNoteLine_CostCodeId",
                schema: "Sales",
                table: "DeliveryNoteLine");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryNoteLine_ProductionOrderId",
                schema: "Sales",
                table: "DeliveryNoteLine");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryNoteLine_SubcontractBOQId",
                schema: "Sales",
                table: "DeliveryNoteLine");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryNoteLine_WBSId",
                schema: "Sales",
                table: "DeliveryNoteLine");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Sales",
                table: "DeliveryNoteLine",
                newName: "BOQItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionOrderLine_ProductionOrder_ProductionOrderId",
                schema: "Manufacturing",
                table: "ProductionOrderLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
