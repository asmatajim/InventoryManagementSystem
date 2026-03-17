using KTMPOS.DAL.Entities.Users;

namespace KTMPOS.DAL.Entities.Inventory
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public AppUser CreatedByUser { get; set; }
        public AppUser ModifiedByUser { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; }
    }
}