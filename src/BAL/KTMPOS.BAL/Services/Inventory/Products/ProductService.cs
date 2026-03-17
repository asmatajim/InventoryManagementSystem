using FluentValidation;

using KTMPOS.Common.Constants;
using KTMPOS.Common.Model.Common;
using KTMPOS.Common.Model.Inventory.Products;
using KTMPOS.Common.Utilities;
using KTMPOS.DAL.Entities.Inventory;
using KTMPOS.DAL.Repositories.Inventory.Products;

namespace KTMPOS.BAL.Services.Inventory.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IValidator<ProductCreate> _productCreateValidator;
        private readonly IValidator<ProductUpdate> _productUpdateValidator;
        private const string _module = "Product";

        public ProductService(IProductRepository productRepository, IValidator<ProductCreate> productCreateValidator,
                              IValidator<ProductUpdate> productUpdateValidator)
        {
            _productRepository = productRepository;
            _productCreateValidator = productCreateValidator;
            _productUpdateValidator = productUpdateValidator;
        }

        #region Read

        public async Task<Output<ProductRead>> GetAllAsync()
        {
            try
            {
                var productList = await _productRepository.GetAllAsync();
                var products = productList
                               .Select((x, index) => new ProductRead
                               {
                                   SN = index + 1,
                                   Id = x.Id,
                                   Name = x.Name,
                                   Category = x.SubCategory.Category.Name,
                                   SubCategory = x.SubCategory.Name,
                                   PurchasePrice = x.PurchasePrice,
                                   SellingPrice = x.SellingPrice,
                                   Stock = x.Stock,
                                   CreatedBy = x.CreatedByUser.UserName,
                                   CreatedDate = x.CreatedDate.FormatDate(),
                                   ModifiedBy = x.ModifiedByUser?.UserName,
                                   ModifiedDate = x.ModifiedDate.FormatDate()
                               })
                               .ToList();
                return OutputConverter.SetSuccess(products);
            }
            catch(Exception ex)
            {
                return OutputConverter.SetFailed<ProductRead>(ex.Message);
            }
        }

        public async Task<Output<Dropdown>> FetchAllAsync()
        {
            try
            {
                var productList = await _productRepository.FetchAllAsync();
                var products = productList
                               .Select(x => new Dropdown
                               {
                                   Id = x.Id,
                                   Name = x.Name
                               })
                               .ToList();
                return OutputConverter.SetSuccess(products);
            }
            catch(Exception ex)
            {
                return OutputConverter.SetFailed<Dropdown>(ex.Message);
            }
        }

        public async Task<Output<ProductDetail>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _productRepository.GetByIdAsync(id);
                ProductDetail detail = new()
                {
                    Name = result.Name,
                    CategoryId = result.SubCategory.CategoryId,
                    SubCategoryId = result.SubCategoryId,
                    SubCategory = result.SubCategory.Name,
                    CreatedBy = result.CreatedBy,
                    PurchasePrice = result.PurchasePrice.ToString(),
                    SellingPrice = result.SellingPrice.ToString()
                };
                return OutputConverter.SetSuccess([detail]);
            }
            catch(Exception ex)
            {
                return OutputConverter.SetFailed<ProductDetail>(ex.Message);
            }
        }

        #endregion Read

        #region Write

        public async Task<Output> SaveAsync(ProductCreate request)
        {
            try
            {
                var result = await _productCreateValidator.ValidateAsync(request);
                if(!result.IsValid)
                {
                    return OutputConverter.SetFailed(result);
                }

                Product entity = new()
                {
                    Name = request.Name,
                    SubCategoryId = request.SubCategoryId,
                    PurchasePrice = request.PurchasePrice,
                    SellingPrice = request.SellingPrice,
                    CreatedBy = request.CreatedBy,
                };
                await _productRepository.SaveAsync(entity);
                return OutputConverter.SetSuccess($"{_module} {Operation.Save} {Message.Successfully}.");
            }
            catch(Exception ex)
            {
                return OutputConverter.SetFailed(ex.Message);
            }
        }

        public async Task<Output> UpdateAsync(ProductUpdate request)
        {
            try
            {
                var result = await _productUpdateValidator.ValidateAsync(request);
                if(!result.IsValid)
                {
                    return OutputConverter.SetFailed(result);
                }

                Product entity = new()
                {
                    Id = request.Id,
                    Name = request.Name,
                    SubCategoryId = request.SubCategoryId,
                    PurchasePrice = request.PurchasePrice,
                    SellingPrice = request.SellingPrice,
                    ModifiedBy = request.CreatedBy,
                };
                await _productRepository.UpdateAsync(entity);
                return OutputConverter.SetSuccess($"{_module} {Operation.Update} {Message.Successfully}.");
            }
            catch(Exception ex)
            {
                return OutputConverter.SetFailed(ex.Message);
            }
        }

        public async Task<Output> DeleteAsync(int id)
        {
            try
            {
                await _productRepository.DeleteAsync(id);
                return OutputConverter.SetSuccess($"{_module} {Operation.Delete} {Message.Successfully}.");
            }
            catch(Exception ex)
            {
                return OutputConverter.SetFailed(ex.Message);
            }
        }

        #endregion Write
    }
}