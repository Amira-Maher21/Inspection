using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addPostingEngine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostingDocumentType",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostingDocumentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostingAccountMapping",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostingKey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountSource = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostingDocumentTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ChartOfAccountId = table.Column<long>(type: "bigint", nullable: true),
                    Side = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostingAccountMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostingAccountMapping_ChartOfAccount_ChartOfAccountId",
                        column: x => x.ChartOfAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostingAccountMapping_PostingDocumentType_PostingDocumentTypeId",
                        column: x => x.PostingDocumentTypeId,
                        principalSchema: "Accounting",
                        principalTable: "PostingDocumentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostingAccountMapping_ChartOfAccountId",
                schema: "Accounting",
                table: "PostingAccountMapping",
                column: "ChartOfAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PostingAccountMapping_PostingDocumentTypeId",
                schema: "Accounting",
                table: "PostingAccountMapping",
                column: "PostingDocumentTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostingAccountMapping",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "PostingDocumentType",
                schema: "Accounting");
        }
    }
}
