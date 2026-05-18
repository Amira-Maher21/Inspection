using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DocumentShare1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentShare",
                schema: "DMS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Tenant_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentShare", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentShare_ShareToken",
                schema: "DMS",
                table: "DocumentShare",
                column: "ShareToken",
                unique: true,
                filter: "[ShareToken] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentShare",
                schema: "DMS");
        }
    }
}
