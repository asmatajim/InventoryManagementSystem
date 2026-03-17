using KTMPOS.Common.Model.Inventory.SubCategories;

namespace KTMPOS.Common.Model.Inventory.Products
{
    public class ProductRead : SubCategoryRead
    {
        public string SubCategory { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int Stock { get; set; }
    }
}