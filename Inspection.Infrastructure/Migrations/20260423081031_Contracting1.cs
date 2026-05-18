using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Contracting1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Division",
                schema: "Contracting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    DivisionCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DivisionName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParentDivisionId = table.Column<long>(type: "bigint", nullable: true),
                    IsLeaf = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Division_Division_ParentDivisionId",
                        column: x => x.ParentDivisionId,
                        principalSchema: "Contracting",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WBS",
                schema: "Contracting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationId = table.Column<long>(type: "bigint", nullable: false),
                    ParentWBSId = table.Column<long>(type: "bigint", nullable: true),
                    WBSCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WBSName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LevelNo = table.Column<int>(type: "int", nullable: false),
                    IsLeaf = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WBS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WBS_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WBS_WBS_ParentWBSId",
                        column: x => x.ParentWBSId,
                        principalSchema: "Contracting",
                        principalTable: "WBS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CostCode",
                schema: "Contracting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostCodeValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CostCodeName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DivisionId = table.Column<long>(type: "bigint", nullable: false),
                    ParentCostCodeId = table.Column<long>(type: "bigint", nullable: true),
                    IsLeaf = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostCode_CostCode_ParentCostCodeId",
                        column: x => x.ParentCostCodeId,
                        principalSchema: "Contracting",
                        principalTable: "CostCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostCode_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "Contracting",
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                schema: "Contracting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationId = table.Column<long>(type: "bigint", nullable: false),
                    WBSId = table.Column<long>(type: "bigint", nullable: false),
                    ActivityCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ActivityName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlannedCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProgressPercent = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activity_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Activity_WBS_WBSId",
                        column: x => x.WBSId,
                        principalSchema: "Contracting",
                        principalTable: "WBS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_OperationId",
                schema: "Contracting",
                table: "Activity",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_SeriesId",
                schema: "Contracting",
                table: "Activity",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_Tenant_ID_CompanyId_ActivityCode",
                schema: "Contracting",
                table: "Activity",
                columns: new[] { "Tenant_ID", "CompanyId", "ActivityCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activity_WBSId",
                schema: "Contracting",
                table: "Activity",
                column: "WBSId");

            migrationBuilder.CreateIndex(
                name: "IX_CostCode_DivisionId",
                schema: "Contracting",
                table: "CostCode",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_CostCode_ParentCostCodeId",
                schema: "Contracting",
                table: "CostCode",
                column: "ParentCostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CostCode_Tenant_ID_CompanyId_CostCodeValue",
                schema: "Contracting",
                table: "CostCode",
                columns: new[] { "Tenant_ID", "CompanyId", "CostCodeValue" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Division_ParentDivisionId",
                schema: "Contracting",
                table: "Division",
                column: "ParentDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Division_Tenant_ID_CompanyId_DivisionCode",
                schema: "Contracting",
                table: "Division",
                columns: new[] { "Tenant_ID", "CompanyId", "DivisionCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WBS_OperationId",
                schema: "Contracting",
                table: "WBS",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_WBS_ParentWBSId",
                schema: "Contracting",
                table: "WBS",
                column: "ParentWBSId");

            migrationBuilder.CreateIndex(
                name: "IX_WBS_Tenant_ID_CompanyId_OperationId_WBSCode",
                schema: "Contracting",
                table: "WBS",
                columns: new[] { "Tenant_ID", "CompanyId", "OperationId", "WBSCode" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity",
                schema: "Contracting");

            migrationBuilder.DropTable(
                name: "CostCode",
                schema: "Contracting");

            migrationBuilder.DropTable(
                name: "WBS",
                schema: "Contracting");

            migrationBuilder.DropTable(
                name: "Division",
                schema: "Contracting");
        }
    }
}
