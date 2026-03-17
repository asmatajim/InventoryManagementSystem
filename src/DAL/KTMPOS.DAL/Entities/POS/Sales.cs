using KTMPOS.DAL.Entities.Users;

namespace KTMPOS.DAL.Entities.POS
{
    public class Sales
    {
        public int Id { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetTotal { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public AppUser CreatedByUser { get; set; }
        public ICollection<SalesDetail> SalesDetails { get; set; }
    }
}