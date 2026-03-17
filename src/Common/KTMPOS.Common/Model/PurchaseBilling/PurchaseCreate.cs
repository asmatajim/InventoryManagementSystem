namespace KTMPOS.Common.Model.PurchaseBilling
{
    public class PurchaseCreate
    {
        public int SupplierId { get; set; }
        public int CreatedBy { get; set; }
        public List<PurchaseDetailCreate> PurchaseDetails { get; set; }
    }

    public class PurchaseDetailCreate
    {
        public int ProductId { get; set; }
        public int Qty { get; set; }
    }
}