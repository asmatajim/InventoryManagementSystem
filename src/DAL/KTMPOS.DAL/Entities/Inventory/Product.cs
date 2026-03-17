using KTMPOS.DAL.Entities.POS;
using KTMPOS.DAL.Entities.PurchaseBilling;
using KTMPOS.DAL.Entities.Users;

namespace KTMPOS.DAL.Entities.Inventory
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int SubCategoryId { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int Stock { get; set; }
        public SubCategory SubCategory { get; set; }
        public AppUser CreatedByUser { get; set; }
        public AppUser ModifiedByUser { get; set; }
        public ICollection<PurchaseDetail> PurchaseDetails { get; set; }
        public ICollection<SalesDetail> SalesDetails { get; set; }
    }
}