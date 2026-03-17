using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KTMPOS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedPreComputedNetTotal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_SalesDetail_SubTotal",
                table: "SalesDetails");

            migrationBuilder.DropCheckConstraint(
                name: "CK_SubTotal",
                table: "PurchaseDetails");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountAmount",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercent",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "SubTotal",
                table: "SalesDetails",
                type: "decimal(18,2)",
                nullable: false,
                computedColumnSql: "[Qty] * [UnitPrice]",
                stored: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "NetTotal",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                computedColumnSql: "[GrandTotal] - [DiscountAmount]",
                stored: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SubTotal",
                table: "PurchaseDetails",
                type: "decimal(18,2)",
                nullable: false,
                computedColumnSql: "[Qty] * [UnitPrice]",
                stored: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NetTotal",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "Sales");

            migrationBuilder.AlterColumn<decimal>(
                name: "SubTotal",
                table: "SalesDetails",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComputedColumnSql: "[Qty] * [UnitPrice]");

            migrationBuilder.AlterColumn<decimal>(
                name: "SubTotal",
                table: "PurchaseDetails",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComputedColumnSql: "[Qty] * [UnitPrice]");

            migrationBuilder.AddCheckConstraint(
                name: "CK_SalesDetail_SubTotal",
                table: "SalesDetails",
                sql: "[SubTotal] > 0 AND ([SubTotal] = [Qty] * [UnitPrice])");

            migrationBuilder.AddCheckConstraint(
                name: "CK_SubTotal",
                table: "PurchaseDetails",
                sql: "[SubTotal] > 0 AND ([SubTotal] = [Qty] * [UnitPrice])");
        }
    }
}
