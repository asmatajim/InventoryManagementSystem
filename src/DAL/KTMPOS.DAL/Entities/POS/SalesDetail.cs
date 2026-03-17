using KTMPOS.DAL.Entities.Inventory;

namespace KTMPOS.DAL.Entities.POS
{
    public class SalesDetail
    {
        public int Id { get; set; }
        public int SalesId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }
        public decimal SubTotal { get; set; }
        public Sales Sales { get; set; }
        public Product Product { get; set; }
    }
}