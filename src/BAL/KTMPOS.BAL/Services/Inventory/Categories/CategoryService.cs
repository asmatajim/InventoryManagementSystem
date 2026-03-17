using FluentValidation;

using KTMPOS.Common.Constants;
using KTMPOS.Common.Model.Common;
using KTMPOS.Common.Model.Inventory.Categories;
using KTMPOS.Common.Utilities;
using KTMPOS.DAL.Entities.Inventory;
using KTMPOS.DAL.Repositories.Inventory.Categories;

namespace KTMPOS.BAL.Services.Inventory.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IValidator<CategoryCreate> _createValidator;
        private readonly IValidator<CategoryUpdate> _updateValidator;
        private const string _module = "Category";

        public CategoryService(ICategoryRepository categoryRepository, IValidator<CategoryCreate> createValidator,
                               IValidator<CategoryUpdate> updateValidator)
        {
            _categoryRepository = categoryRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        #region Read

        public async Task<Output<CategoryRead>> GetAllAsync()
        {
            try
            {
                var list = await _categoryRepository.GetAllAsync();
                var result = list
                             .Select((x, index) => new CategoryRead
                             {
                                 SN = index + 1,
                                 Id = x.Id,
                                 Name = x.Name,
                                 CreatedBy = x.CreatedByUser.UserName,
                                 CreatedDate = x.CreatedDate.FormatDate(),
                                 ModifiedBy = x.ModifiedByUser?.UserName,
                                 ModifiedDate = x.ModifiedDate.FormatDate()
                             }).ToList();
                return OutputConverter.SetSuccess(result);
            }
            catch(Exception ex)
            {
                return OutputConverter.SetFailed<CategoryRead>(ex.Message);
            }
        }

        public async Task<Output<Dropdown>> FetchAllAsync()
        {
            try
            {
                var list = await _categoryRepository.FetchAllAsync();
                var result = list
                             .Select(x => new Dropdown
                             {
                                 Id = x.Id,
                                 Name = x.Name
                             }).ToList();
                return OutputConverter.SetSuccess(result);
            }
            catch(Exception ex)
            {
                return OutputConverter.SetFailed<Dropdown>(ex.Message);
            }
        }

        public async Task<Output<CategoryDetail>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _categoryRepository.GetByIdAsync(id);
                CategoryDetail detail = new()
                {
                    Id = result.Id,
                    Name = result.Name,
                };
                return OutputConverter.SetSuccess([detail]);
            }
            catch(Exception ex)
            {
                return OutputConverter.SetFailed<CategoryDetail>(ex.Message);
            }
        }

        #endregion Read

        #region Write

        public async Task<Output> SaveAsync(CategoryCreate request)
        {
            try
            {
                var result = await _createValidator.ValidateAsync(request);
                if(!result.IsValid)
                {
                    return OutputConverter.SetFailed(result);
                }

                Category entity = new()
                {
                    Name = request.Name,
                    CreatedBy = request.CreatedBy,
                };
                await _categoryRepository.SaveAsync(entity);
                return OutputConverter.SetSuccess($"{_module} {Operation.Save} {Message.Successfully}.");
            }
            catch(Exception ex)
            {
                return OutputConverter.SetFailed(ex.Message);
            }
        }

        public async Task<Output> UpdateAsync(CategoryUpdate request)
        {
            try
            {
                var result = await _updateValidator.ValidateAsync(request);
                if(!result.IsValid)
                {
                    return OutputConverter.SetFailed(result);
                }

                Category entity = new()
                {
                    Id = request.Id,
                    Name = request.Name,
                    ModifiedBy = request.CreatedBy,
                };
                await _categoryRepository.UpdateAsync(entity);
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
                await _categoryRepository.DeleteAsync(id);
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