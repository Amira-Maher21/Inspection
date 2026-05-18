using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDocumentComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentComment",
                schema: "DMS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsResolved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ParentCommentId = table.Column<long>(type: "bigint", nullable: true),
                    DocumentId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ResolvedById = table.Column<long>(type: "bigint", nullable: true),
                    ResolvedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentComment_DocumentComment_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalSchema: "DMS",
                        principalTable: "DocumentComment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentComment_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "DMS",
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentComment_User_Code_ResolvedById",
                        column: x => x.ResolvedById,
                        principalSchema: "Sec",
                        principalTable: "User_Code",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentComment_User_Code_UserId",
                        column: x => x.UserId,
                        principalSchema: "Sec",
                        principalTable: "User_Code",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentComment_DocumentId",
                schema: "DMS",
                table: "DocumentComment",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentComment_ParentCommentId",
                schema: "DMS",
                table: "DocumentComment",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentComment_ResolvedById",
                schema: "DMS",
                table: "DocumentComment",
                column: "ResolvedById");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentComment_Tenant_ID_CompanyId_DocumentId",
                schema: "DMS",
                table: "DocumentComment",
                columns: new[] { "Tenant_ID", "CompanyId", "DocumentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentComment_UserId",
                schema: "DMS",
                table: "DocumentComment",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentComment",
                schema: "DMS");
        }
    }
}
