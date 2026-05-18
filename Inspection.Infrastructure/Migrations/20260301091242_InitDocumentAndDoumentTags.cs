using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDocumentAndDoumentTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Document",
                schema: "DMS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalFilename = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    FileHash = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    StorageType = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    URL = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    StoragePath = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    StorageBucket = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FolderId = table.Column<long>(type: "bigint", nullable: true),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VersionNumber = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsLatestVersion = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ParentDocumentId = table.Column<long>(type: "bigint", nullable: true),
                    SearchableContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    DownloadCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ShareCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    LastAccessedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastAccessedById = table.Column<long>(type: "bigint", nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_Document_ParentDocumentId",
                        column: x => x.ParentDocumentId,
                        principalSchema: "DMS",
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Document_Folder_FolderId",
                        column: x => x.FolderId,
                        principalSchema: "DMS",
                        principalTable: "Folder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentEntityLink",
                schema: "DMS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<long>(type: "bigint", nullable: false),
                    ScreenId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LinkedEntityType = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentEntityLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentEntityLink_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "DMS",
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentEntityLink_Document_DocumentId1",
                        column: x => x.DocumentId1,
                        principalSchema: "DMS",
                        principalTable: "Document",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocumentTag",
                schema: "DMS",
                columns: table => new
                {
                    DocumentId = table.Column<long>(type: "bigint", nullable: false),
                    TagId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTag", x => new { x.DocumentId, x.TagId });
                    table.ForeignKey(
                        name: "FK_DocumentTag_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "DMS",
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentTag_Tag_TagId",
                        column: x => x.TagId,
                        principalSchema: "DMS",
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document_DocumentNumber",
                schema: "DMS",
                table: "Document",
                column: "DocumentNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Document_FileHash",
                schema: "DMS",
                table: "Document",
                column: "FileHash");

            migrationBuilder.CreateIndex(
                name: "IX_Document_FolderId",
                schema: "DMS",
                table: "Document",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_ParentDocumentId",
                schema: "DMS",
                table: "Document",
                column: "ParentDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_Tenant_ID_CompanyId_DocumentNumber",
                schema: "DMS",
                table: "Document",
                columns: new[] { "Tenant_ID", "CompanyId", "DocumentNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentEntityLink_DocumentId",
                schema: "DMS",
                table: "DocumentEntityLink",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentEntityLink_DocumentId_ScreenId_EntityId",
                schema: "DMS",
                table: "DocumentEntityLink",
                columns: new[] { "DocumentId", "ScreenId", "EntityId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentEntityLink_DocumentId1",
                schema: "DMS",
                table: "DocumentEntityLink",
                column: "DocumentId1");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentEntityLink_ScreenId_EntityId",
                schema: "DMS",
                table: "DocumentEntityLink",
                columns: new[] { "ScreenId", "EntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTag_DocumentId_TagId",
                schema: "DMS",
                table: "DocumentTag",
                columns: new[] { "DocumentId", "TagId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTag_TagId",
                schema: "DMS",
                table: "DocumentTag",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentEntityLink",
                schema: "DMS");

            migrationBuilder.DropTable(
                name: "DocumentTag",
                schema: "DMS");

            migrationBuilder.DropTable(
                name: "Document",
                schema: "DMS");
        }
    }
}
