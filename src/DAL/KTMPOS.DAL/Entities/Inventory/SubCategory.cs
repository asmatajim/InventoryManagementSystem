using KTMPOS.DAL.Entities.Users;

namespace KTMPOS.DAL.Entities.Inventory
{
    public class SubCategory : BaseEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public AppUser CreatedByUser { get; set; }
        public AppUser ModifiedByUser { get; set; }
        public Category Category { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}