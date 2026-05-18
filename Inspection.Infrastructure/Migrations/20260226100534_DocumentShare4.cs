using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DocumentShare4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Program_ID",
                schema: "Syst",
                table: "Menu",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DocumentShare",
                schema: "DMS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    SharedById = table.Column<long>(type: "bigint", nullable: false),
                    SharedWithId = table.Column<long>(type: "bigint", nullable: true),
                    ShareTypeEnum = table.Column<int>(type: "int", nullable: false),
                    ShareToken = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    CanView = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CanDownload = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CanEdit = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RequirePassword = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastAccessedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccessCount = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    RevokedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedById = table.Column<long>(type: "bigint", nullable: true),
                    Tenant_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentShare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentShare_User_Code_RevokedById",
                        column: x => x.RevokedById,
                        principalSchema: "Sec",
                        principalTable: "User_Code",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentShare_User_Code_SharedById",
                        column: x => x.SharedById,
                        principalSchema: "Sec",
                        principalTable: "User_Code",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentShare_User_Code_SharedWithId",
                        column: x => x.SharedWithId,
                        principalSchema: "Sec",
                        principalTable: "User_Code",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShareAccessLog",
                schema: "DMS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccessIp = table.Column<string>(type: "nvarchar(45)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Action = table.Column<int>(type: "int", nullable: true),
                    DocumentShareId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShareAccessLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShareAccessLog_DocumentShare_DocumentShareId",
                        column: x => x.DocumentShareId,
                        principalSchema: "DMS",
                        principalTable: "DocumentShare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentShare_RevokedById",
                schema: "DMS",
                table: "DocumentShare",
                column: "RevokedById");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentShare_SharedById",
                schema: "DMS",
                table: "DocumentShare",
                column: "SharedById");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentShare_SharedWithId",
                schema: "DMS",
                table: "DocumentShare",
                column: "SharedWithId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentShare_ShareToken",
                schema: "DMS",
                table: "DocumentShare",
                column: "ShareToken",
                unique: true,
                filter: "[ShareToken] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShareAccessLog_DocumentShareId",
                schema: "DMS",
                table: "ShareAccessLog",
                column: "DocumentShareId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShareAccessLog",
                schema: "DMS");

            migrationBuilder.DropTable(
                name: "DocumentShare",
                schema: "DMS");

            migrationBuilder.AlterColumn<string>(
                name: "Program_ID",
                schema: "Syst",
                table: "Menu",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6,
                oldNullable: true);
        }
    }
}
