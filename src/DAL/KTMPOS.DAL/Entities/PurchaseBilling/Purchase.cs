using KTMPOS.DAL.Entities.Users;

namespace KTMPOS.DAL.Entities.PurchaseBilling
{
    public class Purchase
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public decimal GrandTotal { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Supplier Supplier { get; set; }
        public AppUser CreatedByUser { get; set; }
        public ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
}