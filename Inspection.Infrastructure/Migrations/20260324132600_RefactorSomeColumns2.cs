using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorSomeColumns2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // أولاً احذف الـ index اللي يعتمد على العمود
            migrationBuilder.DropIndex(
                name: "IX_TaxType_Tenant_ID_Code_TaxTypeValue",
                schema: "Accounting",
                table: "TaxType");

            // بعد حذف الـ index يمكن حذف العمود بأمان
            migrationBuilder.DropColumn(
                name: "TaxTypeValue",
                schema: "Accounting",
                table: "TaxType");

            // التعديلات الجديدة
            migrationBuilder.AddColumn<int>(
                name: "CostingMethods",
                schema: "Inventory",
                table: "ItemGroup",
                type: "int",
                maxLength: 20,
                nullable: false,
                defaultValue: 0);
        }
        /// <inheritdoc />
    }
}
