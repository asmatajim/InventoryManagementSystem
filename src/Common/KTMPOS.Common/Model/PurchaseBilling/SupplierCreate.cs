namespace KTMPOS.Common.Model.PurchaseBilling
{
    public class SupplierCreate
    {
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public int CreatedBy { get; set; }
    }
}