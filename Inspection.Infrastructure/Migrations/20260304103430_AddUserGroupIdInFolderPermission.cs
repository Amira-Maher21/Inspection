using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserGroupIdInFolderPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tenant_ID",
                schema: "DMS",
                table: "FolderPermission",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<long>(
                name: "UserGroupId",
                schema: "DMS",
                table: "FolderPermission",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FolderPermission_Tenant_ID_UserGroupId",
                schema: "DMS",
                table: "FolderPermission",
                columns: new[] { "Tenant_ID", "UserGroupId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FolderPermission_User_Group_Tenant_ID_UserGroupId",
                schema: "DMS",
                table: "FolderPermission",
                columns: new[] { "Tenant_ID", "UserGroupId" },
                principalSchema: "Sec",
                principalTable: "User_Group",
                principalColumns: new[] { "Tenant_ID", "User_group_ID" },
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FolderPermission_User_Group_Tenant_ID_UserGroupId",
                schema: "DMS",
                table: "FolderPermission");

            migrationBuilder.DropIndex(
                name: "IX_FolderPermission_Tenant_ID_UserGroupId",
                schema: "DMS",
                table: "FolderPermission");

            migrationBuilder.DropColumn(
                name: "UserGroupId",
                schema: "DMS",
                table: "FolderPermission");

            migrationBuilder.AlterColumn<string>(
                name: "Tenant_ID",
                schema: "DMS",
                table: "FolderPermission",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }
    }
}
