namespace KTMPOS.Common.Model.PurchaseBilling
{
    public class SupplierRead : SupplierDetail
    {
        public int SN { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }
}