using FluentValidation;

using KTMPOS.Common.Constants;
using KTMPOS.Common.Enumerations;
using KTMPOS.Common.Model.Common;
using KTMPOS.Common.Model.POS;
using KTMPOS.Common.Utilities;
using KTMPOS.DAL.Entities.Inventory;
using KTMPOS.DAL.Entities.POS;
using KTMPOS.DAL.Repositories.Inventory.Products;
using KTMPOS.DAL.Repositories.POS;
using KTMPOS.DAL.Utilities;

namespace KTMPOS.BAL.Services.POS
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IProductRepository _productRepository;
        private readonly ITransactionManager _transactionManager;
        private readonly IValidator<SalesCreate> _createValidator;
        private const string _module = "Sales";

        public SalesService(ISalesRepository salesRepository, IProductRepository productRepository,
                            ITransactionManager transactionManager, IValidator<SalesCreate> createValidator)
        {
            _salesRepository = salesRepository;
            _productRepository = productRepository;
            _transactionManager = transactionManager;
            _createValidator = createValidator;
        }

        public async Task<Output> SaveAsync(SalesCreate request)
        {
            try
            {
                var result = await _createValidator.ValidateAsync(request);
                if(!result.IsValid)
                {
                    return OutputConverter.SetFailed(result);
                }

                var productIds = request
                                 .SalesDetails
                                 .Select(x => x.ProductId)
                                 .ToList();
                var productDetails = await _productRepository.GetByIdAsync(productIds);

                var salesDetails = request
                                   .SalesDetails
                                   .Select(x =>
                                   {
                                       int qty = x.Qty;
                                       decimal unitPrice = productDetails
                                                           .FirstOrDefault(p => p.Id == x.ProductId)
                                                           .SellingPrice;
                                       return new SalesDetail
                                       {
                                           ProductId = x.ProductId,
                                           Qty = qty,
                                           UnitPrice = unitPrice
                                       };
                                   })
                                   .ToList();
                decimal grandTotal = salesDetails
                                     .Sum(x => x.Qty * x.UnitPrice);
                using(var transaction = await _transactionManager.BeginTransactionAsync())
                {
                    try
                    {
                        Sales entity = new()
                        {
                            GrandTotal = grandTotal,
                            DiscountPercent = request.DiscountPercent,
                            DiscountAmount = request.DiscountAmount,
                            CreatedBy = request.CreatedBy,
                            SalesDetails = salesDetails
                        };
                        await _salesRepository.SaveAsync(entity);

                        var products = request
                                       .SalesDetails
                                       .Select(x => new Product
                                       {
                                           Id = x.ProductId,
                                           Stock = x.Qty,
                                           ModifiedBy = request.CreatedBy
                                       })
                                       .ToList();
                        await _productRepository.UpdateStockAsync(products, BillingType.Sales);
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