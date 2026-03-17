using KTMPOS.Common.Model.Inventory.SubCategories;

namespace KTMPOS.Common.Model.Inventory.Products
{
    public class ProductDetail : SubCategoryDetail
    {
        public int SubCategoryId { get; set; }
        public string SubCategory { get; set; }
        public string PurchasePrice { get; set; }
        public string SellingPrice { get; set; }
    }
}