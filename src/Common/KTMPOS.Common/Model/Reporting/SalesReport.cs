namespace KTMPOS.Common.Model.Reporting
{
    public class SalesReport
    {
        public int SN { get; set; }
        public decimal TotalGrossAmount { get; set; }
        public decimal TotalDiscountAmount { get; set; }
        public decimal TotalNetAmount { get; set; }
        public int TotalRecords { get; set; }
    }
}