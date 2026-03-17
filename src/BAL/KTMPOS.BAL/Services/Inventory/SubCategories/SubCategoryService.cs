using FluentValidation;

using KTMPOS.Common.Constants;
using KTMPOS.Common.Model.Common;
using KTMPOS.Common.Model.Inventory.SubCategories;
using KTMPOS.Common.Utilities;
using KTMPOS.DAL.Entities.Inventory;
using KTMPOS.DAL.Repositories.Inventory.SubCategories;

namespace KTMPOS.BAL.Services.Inventory.SubCategories
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IValidator<SubCategoryCreate> _createValidator;
        private readonly IValidator<SubCategoryUpdate> _updateValidator;
        private const string _module = "SubCategory";

        public SubCategoryService(ISubCategoryRepository subCategoryRepository, IValidator<SubCategoryCreate> createValidator,
                                  IValidator<SubCategoryUpdate> updateValidator)
        {
            _subCategoryRepository = subCategoryRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        #region Read

        public async Task<Output<SubCategoryRead>> GetAllAsync()
        {
            try
            {
                var list = await _subCategoryRepository.GetAllAsync();
                var result = list
                             .Select((x, index) => new SubCategoryRead
                             {
                                 SN = index + 1,
                                 Id = x.Id,
                                 Name = x.Name,
                                 Category = x.Category.Name,
                                 CreatedBy = x.CreatedByUser.UserName,
                                 CreatedDate = x.CreatedDate.FormatDate(),
                                 ModifiedBy = x.ModifiedByUser?.UserName,
                                 ModifiedDate = x.ModifiedDate.FormatDate()
                             }).ToList();
                return OutputConverter.SetSuccess(result);
            }
            catch(Exception ex)
            {
                return OutputConverter.SetFailed<SubCategoryRead>(ex.Message);
            }
        }

        public async Task<Output<Dropdown>> FetchByCategoryIdAsync(int categoryId)
        {
            try
            {
                var list = await _subCategoryRepository.FetchByCategoryIdAsync(categoryId);
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

        public async Task<Output<SubCategoryDetail>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _subCategoryRepository.GetByIdAsync(id);
                SubCategoryDetail detail = new()
                {
                    Id = result.Id,
                    Name = result.Name,
                    CategoryId = result.CategoryId
                };
                return OutputConverter.SetSuccess([detail]);
            }
            catch(Exception ex)
            {
                return OutputConverter.SetFailed<SubCategoryDetail>(ex.Message);
            }
        }

        #endregion Read

        #region Write

        public async Task<Output> SaveAsync(SubCategoryCreate request)
        {
            try
            {
                var result = await _createValidator.ValidateAsync(request);
                if(!result.IsValid)
                {
                    return OutputConverter.SetFailed(result);
                }

                SubCategory entity = new()
                {
                    CategoryId = request.CategoryId,
                    Name = request.Name,
                    CreatedBy = request.CreatedBy,
                };
                await _subCategoryRepository.SaveAsync(entity);
                return OutputConverter.SetSuccess($"{_module} {Operation.Save} {Message.Successfully}.");
            }
            catch(Exception ex)
            {
                return OutputConverter.SetFailed(ex.Message);
            }
        }

        public async Task<Output> UpdateAsync(SubCategoryUpdate request)
        {
            try
            {
                var result = await _updateValidator.ValidateAsync(request);
                if(!result.IsValid)
                {
                    return OutputConverter.SetFailed(result);
                }

                SubCategory entity = new()
                {
                    Id = request.Id,
                    CategoryId = request.CategoryId,
                    Name = request.Name,
                    ModifiedBy = request.CreatedBy,
                };
                await _subCategoryRepository.UpdateAsync(entity);
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
                await _subCategoryRepository.DeleteAsync(id);
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