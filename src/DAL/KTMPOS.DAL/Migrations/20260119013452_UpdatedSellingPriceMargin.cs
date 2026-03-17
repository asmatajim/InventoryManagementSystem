using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KTMPOS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSellingPriceMargin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_SellingPrice",
                table: "Products");

            migrationBuilder.AddCheckConstraint(
                name: "CK_SellingPrice",
                table: "Products",
                sql: "[SellingPrice] > 0 AND ([SellingPrice] >= (([PurchasePrice] + [PurchasePrice] * 0.05)) AND [SellingPrice] <= ([PurchasePrice] + ([PurchasePrice] * 0.45)))");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_SellingPrice",
                table: "Products");

            migrationBuilder.AddCheckConstraint(
                name: "CK_SellingPrice",
                table: "Products",
                sql: "[SellingPrice] > 0 AND ([SellingPrice] > (([PurchasePrice] + [PurchasePrice] * 0.05)) AND [SellingPrice] < ([PurchasePrice] + ([PurchasePrice] * 0.45)))");
        }
    }
}
