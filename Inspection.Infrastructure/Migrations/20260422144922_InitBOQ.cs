using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitBOQ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BOQ",
                schema: "Contracting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    OperationId = table.Column<long>(type: "bigint", nullable: false),
                    BOQNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RevisionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentStatus = table.Column<int>(type: "int", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOQ", x => x.Id);
                    table.CheckConstraint("CK_BOQ_DocumentStatus", "[DocumentStatus] IN (1,2,3)");
                    table.CheckConstraint("CK_BOQ_RevisionNumber", "[RevisionNumber] > 0");
                    table.ForeignKey(
                        name: "FK_BOQ_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BOQLine",
                schema: "Contracting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BOQId = table.Column<long>(type: "bigint", nullable: false),
                    BOQItemCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    WBSId = table.Column<long>(type: "bigint", nullable: true),
                    CostCodeId = table.Column<long>(type: "bigint", nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOQLine", x => x.Id);
                    table.CheckConstraint("CK_BOQLine_Amount", "[Amount] = [Quantity] * [Rate]");
                    table.CheckConstraint("CK_BOQLine_Quantity", "[Quantity] > 0");
                    table.CheckConstraint("CK_BOQLine_Rate", "[Rate] >= 0");
                    table.ForeignKey(
                        name: "FK_BOQLine_BOQ_BOQId",
                        column: x => x.BOQId,
                        principalSchema: "Contracting",
                        principalTable: "BOQ",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOQ_OperationId",
                schema: "Contracting",
                table: "BOQ",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_BOQ_Tenant_ID_CompanyId_BOQNumber",
                schema: "Contracting",
                table: "BOQ",
                columns: new[] { "Tenant_ID", "CompanyId", "BOQNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BOQLine_BOQId",
                schema: "Contracting",
                table: "BOQLine",
                column: "BOQId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BOQLine",
                schema: "Contracting");

            migrationBuilder.DropTable(
                name: "BOQ",
                schema: "Contracting");
        }
    }
}
