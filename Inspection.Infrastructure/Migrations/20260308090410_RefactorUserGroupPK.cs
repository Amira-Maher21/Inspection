using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorUserGroupPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // DROP existing foreign keys referencing User_Group
            migrationBuilder.DropForeignKey(
                name: "FK_FolderPermission_User_Group_Tenant_ID_UserGroupId",
                schema: "DMS",
                table: "FolderPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_Screen_permissions_User_groups",
                schema: "Sec",
                table: "Screen_permission");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Code_dGroup_User_Group",
                schema: "Sec",
                table: "User_Code_dGroup");

            // DROP old primary key
            migrationBuilder.DropPrimaryKey(
                name: "PK_User_groups",
                schema: "Sec",
                table: "User_Group");

            // CREATE new primary key (keep Tenant_ID + User_group_ID if you want composite PK)
            // Or use just User_group_ID as PK
            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Group",
                schema: "Sec",
                table: "User_Group",
                column: "User_group_ID");

            // CREATE indexes on Tenant_ID for performance
            migrationBuilder.CreateIndex(
                name: "IX_User_Group_Tenant_ID",
                schema: "Sec",
                table: "User_Group",
                column: "Tenant_ID");

            // CREATE indexes for User_Code_dGroup
            migrationBuilder.CreateIndex(
                name: "IX_User_Code_dGroup_User_group_ID",
                schema: "Sec",
                table: "User_Code_dGroup",
                column: "User_group_ID");

            // CREATE indexes for Screen_permission
            migrationBuilder.CreateIndex(
                name: "IX_Screen_permission_User_group_ID",
                schema: "Sec",
                table: "Screen_permission",
                column: "User_group_ID");

            // CREATE indexes for FolderPermission
            migrationBuilder.CreateIndex(
                name: "IX_FolderPermission_UserGroupId",
                schema: "DMS",
                table: "FolderPermission",
                column: "UserGroupId");

            // ADD foreign keys referencing the new PK
            migrationBuilder.AddForeignKey(
                name: "FK_FolderPermission_User_Group_UserGroupId",
                schema: "DMS",
                table: "FolderPermission",
                column: "UserGroupId",
                principalSchema: "Sec",
                principalTable: "User_Group",
                principalColumn: "User_group_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Screen_permissions_User_groups",
                schema: "Sec",
                table: "Screen_permission",
                column: "User_group_ID",
                principalSchema: "Sec",
                principalTable: "User_Group",
                principalColumn: "User_group_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Code_dGroup_User_Group",
                schema: "Sec",
                table: "User_Code_dGroup",
                column: "User_group_ID",
                principalSchema: "Sec",
                principalTable: "User_Group",
                principalColumn: "User_group_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // DROP new foreign keys
            migrationBuilder.DropForeignKey(
                name: "FK_FolderPermission_User_Group_UserGroupId",
                schema: "DMS",
                table: "FolderPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_Screen_permissions_User_groups",
                schema: "Sec",
                table: "Screen_permission");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Code_dGroup_User_Group",
                schema: "Sec",
                table: "User_Code_dGroup");

            // DROP indexes
            migrationBuilder.DropIndex(
                name: "IX_User_Group_Tenant_ID",
                schema: "Sec",
                table: "User_Group");

            migrationBuilder.DropIndex(
                name: "IX_User_Code_dGroup_User_group_ID",
                schema: "Sec",
                table: "User_Code_dGroup");

            migrationBuilder.DropIndex(
                name: "IX_Screen_permission_User_group_ID",
                schema: "Sec",
                table: "Screen_permission");

            migrationBuilder.DropIndex(
                name: "IX_FolderPermission_UserGroupId",
                schema: "DMS",
                table: "FolderPermission");

            // DROP new PK
            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Group",
                schema: "Sec",
                table: "User_Group");

            // RESTORE old composite PK
            migrationBuilder.AddPrimaryKey(
                name: "PK_User_groups",
                schema: "Sec",
                table: "User_Group",
                columns: new[] { "Tenant_ID", "User_group_ID" });

            // RESTORE foreign keys to match old PK
            migrationBuilder.AddForeignKey(
                name: "FK_FolderPermission_User_Group_Tenant_ID_UserGroupId",
                schema: "DMS",
                table: "FolderPermission",
                columns: new[] { "Tenant_ID", "UserGroupId" },
                principalSchema: "Sec",
                principalTable: "User_Group",
                principalColumns: new[] { "Tenant_ID", "User_group_ID" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Screen_permissions_User_groups",
                schema: "Sec",
                table: "Screen_permission",
                columns: new[] { "Tenant_ID", "User_group_ID" },
                principalSchema: "Sec",
                principalTable: "User_Group",
                principalColumns: new[] { "Tenant_ID", "User_group_ID" });

            migrationBuilder.AddForeignKey(
                name: "FK_User_Code_dGroup_User_Group",
                schema: "Sec",
                table: "User_Code_dGroup",
                columns: new[] { "Tenant_ID", "User_group_ID" },
                principalSchema: "Sec",
                principalTable: "User_Group",
                principalColumns: new[] { "Tenant_ID", "User_group_ID" });
        }
    }
}