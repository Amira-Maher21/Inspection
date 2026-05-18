using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SalesInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activity",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BOQItemId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "bigint",
                nullable: true);


            migrationBuilder.AddColumn<long>(
                name: "CostCentertId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CostCode",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CostUnitId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountAmount",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscountType",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountValue",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FreeItem",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInclusive",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "bit",
                nullable: true);



            migrationBuilder.AddColumn<long>(
                name: "OperationId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProductionOrderId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SubcontractBOQId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true);



            migrationBuilder.AddColumn<long>(
                name: "TaxTypeId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "bigint",
                nullable: true);


            migrationBuilder.AddColumn<long>(
                name: "WBSId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WarehouseId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "bigint",
                nullable: true);


            migrationBuilder.AlterColumn<string>(
                name: "Mod_User",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "In_User",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "AdditionalDiscountAmount",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdditionalDiscountType",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AdditionalDiscountValue",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true);




            migrationBuilder.AddColumn<string>(
                name: "CustomersPurchaseOrder",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomersPurchaseOrderDate",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);




            migrationBuilder.AddColumn<decimal>(
                name: "NetAmount",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);



            migrationBuilder.AddColumn<int>(
                name: "Posting",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "int",
                nullable: true);





            migrationBuilder.AddColumn<string>(
                name: "ShipmentAddress",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ShipmentAmount",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShipmentMethod",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShipmentStatus",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "int",
                nullable: true);




            migrationBuilder.AddColumn<decimal>(
                name: "TotalDiscount",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WarehouseId",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FeeValue",
                schema: "Accounting",
                table: "ModeOfPayment",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SalesInvoiceSalesAdjustment",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesInvoiceId = table.Column<long>(type: "bigint", nullable: false),
                    SalesInvoiceId1 = table.Column<long>(type: "bigint", nullable: false),
                    ChartOfAccountId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CostCentertId = table.Column<long>(type: "bigint", nullable: true),
                    CostUnitId = table.Column<long>(type: "bigint", nullable: true),
                    OperationId = table.Column<long>(type: "bigint", nullable: true),
                    WBSId = table.Column<long>(type: "bigint", nullable: true),
                    CostCode = table.Column<long>(type: "bigint", nullable: true),
                    Activity = table.Column<bool>(type: "bit", nullable: true),
                    BOQItemId = table.Column<long>(type: "bigint", nullable: true),
                    SubcontractBOQId = table.Column<long>(type: "bigint", nullable: true),
                    ProductionOrderId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoiceSalesAdjustment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceSalesAdjustment_ChartOfAccount_ChartOfAccountId",
                        column: x => x.ChartOfAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceSalesAdjustment_CostCenter_CostCentertId",
                        column: x => x.CostCentertId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceSalesAdjustment_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceSalesAdjustment_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceSalesAdjustment_SalesInvoice_SalesInvoiceId",
                        column: x => x.SalesInvoiceId,
                        principalSchema: "Accounting",
                        principalTable: "SalesInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);

                });

            migrationBuilder.CreateTable(
                name: "SalesInvoiceSalesPerson",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SalesInvoiceId = table.Column<long>(type: "bigint", nullable: false),
                    SalesInvoiceId1 = table.Column<long>(type: "bigint", nullable: false),
                    SalesPersonId = table.Column<long>(type: "bigint", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoiceSalesPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceSalesPerson_SalesInvoice_SalesInvoiceId",
                        column: x => x.SalesInvoiceId,
                        principalSchema: "Accounting",
                        principalTable: "SalesInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);

                    table.ForeignKey(
                        name: "FK_SalesInvoiceSalesPerson_SalesPerson_SalesPersonId",
                        column: x => x.SalesPersonId,
                        principalSchema: "Sales",
                        principalTable: "SalesPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceLine_CostCentertId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "CostCentertId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceLine_CostUnitId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "CostUnitId");



            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceLine_OperationId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceLine_TaxTypeId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "TaxTypeId");



            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceLine_WarehouseId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "WarehouseId");





            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoice_WarehouseId",
                schema: "Accounting",
                table: "SalesInvoice",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceSalesAdjustment_ChartOfAccountId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                column: "ChartOfAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceSalesAdjustment_CostCentertId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                column: "CostCentertId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceSalesAdjustment_CostUnitId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceSalesAdjustment_OperationId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceSalesAdjustment_SalesInvoiceId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                column: "SalesInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceSalesAdjustment_SalesInvoiceId1",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                column: "SalesInvoiceId1");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceSalesPerson_SalesInvoiceId",
                schema: "Accounting",
                table: "SalesInvoiceSalesPerson",
                column: "SalesInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceSalesPerson_SalesInvoiceId1",
                schema: "Accounting",
                table: "SalesInvoiceSalesPerson",
                column: "SalesInvoiceId1");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceSalesPerson_SalesPersonId",
                schema: "Accounting",
                table: "SalesInvoiceSalesPerson",
                column: "SalesPersonId");










            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoice_Warehouse_WarehouseId",
                schema: "Accounting",
                table: "SalesInvoice",
                column: "WarehouseId",
                principalSchema: "Inventory",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceLine_CostCenter_CostCentertId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "CostCentertId",
                principalSchema: "Accounting",
                principalTable: "CostCenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceLine_CostUnit_CostUnitId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "CostUnitId",
                principalSchema: "Accounting",
                principalTable: "CostUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);



            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceLine_Operation_OperationId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "OperationId",
                principalSchema: "Sec",
                principalTable: "Operation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceLine_TaxType_TaxTypeId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "TaxTypeId",
                principalSchema: "Accounting",
                principalTable: "TaxType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);



            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceLine_Warehouse_WarehouseId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "WarehouseId",
                principalSchema: "Inventory",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoice_Currency_CurrencyId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoice_Customer_CustomerId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoice_PaymentTerm_PaymentTermsId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoice_SalesOrder_SalesOrderId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoice_SalesPerson_SalesPersonId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoice_Warehouse_WarehouseId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceLine_CostCenter_CostCentertId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceLine_CostUnit_CostUnitId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceLine_Item_ItemId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceLine_Operation_OperationId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceLine_TaxType_TaxTypeId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceLine_UnitOfMeasure_UnitOfMeasureId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceLine_WarehouseLocation_WarehouseLocationId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceLine_Warehouse_WarehouseId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropTable(
                name: "SalesInvoiceSalesAdjustment",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "SalesInvoiceSalesPerson",
                schema: "Accounting");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceLine_CostCentertId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceLine_CostUnitId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceLine_ItemId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceLine_OperationId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceLine_TaxTypeId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceLine_UnitOfMeasureId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceLine_WarehouseId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceLine_WarehouseLocationId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoice_CurrencyId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoice_CustomerId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoice_PaymentTermsId",
                schema: "Accounting",
                table: "SalesInvoice");



            migrationBuilder.DropIndex(
                name: "IX_SalesInvoice_SalesPersonId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoice_Tenant_ID_CompanyId_InvoiceNo",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoice_WarehouseId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "Activity",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "BOQItemId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "Cost",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "CostCentertId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "CostCode",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "CostUnitId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "DiscountType",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "DiscountValue",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "FreeItem",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "IsInclusive",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "ItemId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "OperationId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "ProductionOrderId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "SubcontractBOQId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "TaxAmount",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "TaxRate",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "TaxTypeId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasureId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "WBSId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "WarehouseLocationId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "AdditionalDiscountAmount",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "AdditionalDiscountType",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "AdditionalDiscountValue",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "BranchId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "CustomersPurchaseOrder",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "CustomersPurchaseOrderDate",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "InvoiceDate",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "InvoiceNo",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "NetAmount",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "PaymentDueDate",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "PaymentTermsId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "Posting",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "SalesOrderId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "SalesPersonId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "ShipmentAddress",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "ShipmentAmount",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "ShipmentMethod",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "ShipmentStatus",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "TaxAmount",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "TotalDiscount",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.AlterColumn<string>(
                name: "Mod_User",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "In_User",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<float>(
                name: "FeeValue",
                schema: "Accounting",
                table: "ModeOfPayment",
                type: "real",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}
