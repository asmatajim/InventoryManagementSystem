using KTMPOS.Common.Model.Inventory.Categories;

namespace KTMPOS.Common.Model.Inventory.Products
{
    public class ProductCreate : CategoryCreate
    {
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
    }
}