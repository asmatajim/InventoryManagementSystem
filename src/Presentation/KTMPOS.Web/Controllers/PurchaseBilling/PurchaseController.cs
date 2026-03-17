using KTMPOS.BAL.Services.Inventory.Products;
using KTMPOS.BAL.Services.PurchaseBilling;

namespace KTMPOS.Web.Controllers.PurchaseBilling
{
    public partial class PurchaseController : BaseController
    {
        private readonly IProductService _productService;
        private readonly ISupplierService _supplierService;
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IProductService productService, ISupplierService supplierService,
                                  IPurchaseService purchaseService)
        {
            _productService = productService;
            _supplierService = supplierService;
            _purchaseService = purchaseService;
        }
    }
}