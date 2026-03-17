using KTMPOS.Common.Model.PurchaseBilling;

namespace KTMPOS.Common.Model.POS
{
    public class SalesCreate
    {
        public int CreatedBy { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountAmount { get; set; }
        public List<SalesDetailCreate> SalesDetails { get; set; }
    }

    public class SalesDetailCreate : PurchaseDetailCreate
    {
    }
}