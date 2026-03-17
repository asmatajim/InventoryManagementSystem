using KTMPOS.DAL.Entities.Inventory;
using KTMPOS.DAL.Entities.POS;
using KTMPOS.DAL.Entities.PurchaseBilling;

using Microsoft.AspNetCore.Identity;

namespace KTMPOS.DAL.Entities.Users
{
    public class AppUser : IdentityUser<int>
    {
        public DateTime? CreatedDate { get; set; }
        public ICollection<Category> CreatedCategories { get; set; }
        public ICollection<Category> ModifiedCategories { get; set; }
        public ICollection<SubCategory> CreatedSubCategories { get; set; }
        public ICollection<SubCategory> ModifiedSubCategories { get; set; }
        public ICollection<Product> CreatedProducts { get; set; }
        public ICollection<Product> ModifiedProducts { get; set; }
        public ICollection<Supplier> CreatedSuppliers { get; set; }
        public ICollection<Supplier> ModifiedSuppliers { get; set; }
        public ICollection<Purchase> CreatedPurchases { get; set; }
        public ICollection<Sales> CreatedSales { get; set; }
    }
}