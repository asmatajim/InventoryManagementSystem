using KTMPOS.DAL.Entities.Users;

namespace KTMPOS.DAL.Entities.PurchaseBilling
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public AppUser CreatedByUser { get; set; }
        public AppUser ModifiedByUser { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
    }
}