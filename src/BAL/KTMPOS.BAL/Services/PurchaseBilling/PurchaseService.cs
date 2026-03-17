using FluentValidation;

using KTMPOS.Common.Constants;
using KTMPOS.Common.Model.Common;
using KTMPOS.Common.Model.PurchaseBilling;
using KTMPOS.Common.Utilities;
using KTMPOS.DAL.Entities.Inventory;
using KTMPOS.DAL.Entities.PurchaseBilling;
using KTMPOS.DAL.Repositories.Inventory.Products;
using KTMPOS.DAL.Repositories.PurchaseBilling;
using KTMPOS.DAL.Utilities;

namespace KTMPOS.BAL.Services.PurchaseBilling
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IProductRepository _productRepository;
        private readonly ITransactionManager _transactionManager;
        private readonly IValidator<PurchaseCreate> _createValidator;
        private const string _module = "Purchase";

        public PurchaseService(IPurchaseRepository purchaseRepository, IProductRepository productRepository,
                               ITransactionManager transactionManager, IValidator<PurchaseCreate> createValidator)
        {
            _purchaseRepository = purchaseRepository;
            _productRepository = productRepository;
            _transactionManager = transactionManager;
            _createValidator = createValidator;
        }

        public async Task<Output> SaveAsync(PurchaseCreate request)
        {
            try
            {
                var result = await _createValidator.ValidateAsync(request);
                if(!result.IsValid)
                {
                    return OutputConverter.SetFailed(result);
                }

                var productIds = request
                                 .PurchaseDetails
                                 .Select(x => x.ProductId)
                                 .ToList();
                var productDetails = await _productRepository.GetByIdAsync(productIds);

                var purchaseDetails = request
                                      .PurchaseDetails
                                      .Select(x =>
                                      {
                                          int qty = x.Qty;
                                          decimal unitPrice = productDetails
                                                              .FirstOrDefault(p => p.Id == x.ProductId)
                                                              .PurchasePrice;
                                          return new PurchaseDetail
                                          {
                                              ProductId = x.ProductId,
                                              Qty = qty,
                                              UnitPrice = unitPrice
                                          };
                                      })
                                      .ToList();
                decimal grandTotal = purchaseDetails
                                     .Sum(x => x.Qty * x.UnitPrice);
                using(var transaction = await _transactionManager.BeginTransactionAsync())
                {
                    try
                    {
                        Purchase entity = new()
                        {
                            SupplierId = request.SupplierId,
                            GrandTotal = grandTotal,
                            CreatedBy = request.CreatedBy,
                            PurchaseDetails = purchaseDetails
                        };
                        await _purchaseRepository.SaveAsync(entity);

                        var products = request
                                       .PurchaseDetails
                                       .Select(x => new Product
                                       {
                                           Id = x.ProductId,
                                           Stock = x.Qty,
                                           ModifiedBy = request.CreatedBy
                                       })
                                       .ToList();
                        await _productRepository.UpdateStockAsync(products);
                        await transaction.CommitAsync();
                        return OutputConverter.SetSuccess($"{_module} {Operation.Save} {Message.Successfully}.");
                    }
                    catch(Exception)
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }
                }
            }
            catch(Exception ex)
            {
                return OutputConverter.SetFailed(ex.Message);
            }
        }
    }
}