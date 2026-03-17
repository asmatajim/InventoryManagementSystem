namespace KTMPOS.Common.Model.PurchaseBilling
{
    public class PurchaseGrid
    {
        public int SN { get; set; }
        public int ProductId { get; set; }
        public string Product { get; set; }
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }
        public decimal SubTotal { get; set; }
    }
}