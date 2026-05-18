using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixUserCodeGroupRelationAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Code_dGroup2");

            migrationBuilder.CreateTable(
                name: "User_Code_dGroup",
                schema: "Sec",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    User_CodeId = table.Column<long>(type: "bigint", nullable: false),
                    User_group_ID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Code_dGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Code_dGroup_User_Code",
                        column: x => x.User_CodeId,
                        principalSchema: "Sec",
                        principalTable: "User_Code",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Code_dGroup_User_Group",
                        columns: x => new { x.Tenant_ID, x.User_group_ID },
                        principalSchema: "Sec",
                        principalTable: "User_Group",
                        principalColumns: new[] { "Tenant_ID", "User_group_ID" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Code_dGroup_Tenant_ID_User_group_ID",
                schema: "Sec",
                table: "User_Code_dGroup",
                columns: new[] { "Tenant_ID", "User_group_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_User_Code_dGroup_User_CodeId",
                schema: "Sec",
                table: "User_Code_dGroup",
                column: "User_CodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Code_dGroup",
                schema: "Sec");

            migrationBuilder.CreateTable(
                name: "User_Code_dGroup2",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_CodeId = table.Column<long>(type: "bigint", nullable: true),
                    User_GroupTenant_ID = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    User_group_ID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Code_dGroup2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Code_dGroup2_User_Code_User_CodeId",
                        column: x => x.User_CodeId,
                        principalSchema: "Sec",
                        principalTable: "User_Code",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Code_dGroup2_User_Group_User_GroupTenant_ID_User_group_ID",
                        columns: x => new { x.User_GroupTenant_ID, x.User_group_ID },
                        principalSchema: "Sec",
                        principalTable: "User_Group",
                        principalColumns: new[] { "Tenant_ID", "User_group_ID" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Code_dGroup2_User_CodeId",
                table: "User_Code_dGroup2",
                column: "User_CodeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Code_dGroup2_User_GroupTenant_ID_User_group_ID",
                table: "User_Code_dGroup2",
                columns: new[] { "User_GroupTenant_ID", "User_group_ID" });
        }
    }
}
