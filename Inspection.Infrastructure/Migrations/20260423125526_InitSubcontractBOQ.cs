using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitSubcontractBOQ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "RevisionNumber",
                schema: "Contracting",
                table: "BOQ",
                type: "real",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "SubcontractBOQ",
                schema: "Contracting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    OperationId = table.Column<long>(type: "bigint", nullable: false),
                    SubcontractBOQNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RevisionNumber = table.Column<float>(type: "real", nullable: false),
                    DocumentStatus = table.Column<int>(type: "int", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubcontractBOQ", x => x.Id);
                    table.CheckConstraint("CK_SubcontractBOQ_DocumentStatus", "[DocumentStatus] IN (1,2,3)");
                    table.ForeignKey(
                        name: "FK_SubcontractBOQ_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubcontractBOQLine",
                schema: "Contracting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubcontractBOQId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_SubcontractBOQLine", x => x.Id);
                    table.CheckConstraint("CK_SubcontractBOQLine_Amount", "[Amount] = [Quantity] * [Rate]");
                    table.CheckConstraint("CK_SubcontractBOQLine_Quantity", "[Quantity] > 0");
                    table.CheckConstraint("CK_SubcontractBOQLine_Rate", "[Rate] >= 0");
                    table.ForeignKey(
                        name: "FK_SubcontractBOQLine_SubcontractBOQ_SubcontractBOQId",
                        column: x => x.SubcontractBOQId,
                        principalSchema: "Contracting",
                        principalTable: "SubcontractBOQ",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubcontractBOQ_OperationId",
                schema: "Contracting",
                table: "SubcontractBOQ",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_SubcontractBOQ_Tenant_ID_CompanyId_SubcontractBOQNumber",
                schema: "Contracting",
                table: "SubcontractBOQ",
                columns: new[] { "Tenant_ID", "CompanyId", "SubcontractBOQNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubcontractBOQLine_SubcontractBOQId",
                schema: "Contracting",
                table: "SubcontractBOQLine",
                column: "SubcontractBOQId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubcontractBOQLine",
                schema: "Contracting");

            migrationBuilder.DropTable(
                name: "SubcontractBOQ",
                schema: "Contracting");

            migrationBuilder.AlterColumn<string>(
                name: "RevisionNumber",
                schema: "Contracting",
                table: "BOQ",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
