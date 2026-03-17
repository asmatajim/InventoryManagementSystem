using KTMPOS.DAL.Entities.Inventory;

namespace KTMPOS.DAL.Entities.PurchaseBilling
{
    public class PurchaseDetail
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }
        public decimal SubTotal { get; set; }
        public Purchase Purchase { get; set; }
        public Product Product { get; set; }
    }
}