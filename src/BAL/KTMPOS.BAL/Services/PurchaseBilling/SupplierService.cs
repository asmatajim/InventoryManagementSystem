using FluentValidation;

using KTMPOS.Common.Constants;
using KTMPOS.Common.Model.Common;
using KTMPOS.Common.Model.PurchaseBilling;
using KTMPOS.Common.Utilities;
using KTMPOS.DAL.Entities.PurchaseBilling;
using KTMPOS.DAL.Repositories.PurchaseBilling;

namespace KTMPOS.BAL.Services.PurchaseBilling
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IValidator<SupplierCreate> _createValidator;
        private readonly IValidator<SupplierUpdate> _updateValidator;
        private const string _module = "Supplier";

        public SupplierService(ISupplierRepository supplierRepository, IValidator<SupplierCreate> createValidator,
                               IValidator<SupplierUpdate> updateValidator)
        {
            _supplierRepository = supplierRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        #region Read

        public async Task<Output<SupplierRead>> GetAllAsync()
        {
            try
            {
                var list = await _supplierRepository.GetAllAsync();
                var result = list
                             .Select((x, index) => new SupplierRead
                             {
                                 SN = index + 1,
                                 Id = x.Id,
                                 Name = x.Name,
                                 ContactPerson = x.ContactPerson,
                                 PhoneNumber = x.PhoneNumber,
                                 EmailAddress = x.EmailAddress,
                                 Address = x.Address,
                                 CreatedBy = x.CreatedByUser.UserName,
                                 CreatedDate = x.CreatedDate.FormatDate(),
                                 ModifiedBy = x.ModifiedByUser?.UserName,
                                 ModifiedDate = x.ModifiedDate.FormatDate()
                             }).ToList();
                return OutputConverter.SetSuccess(result);
            }
            catch(Exception ex)
            {
                return OutputConverter.SetFailed<SupplierRead>(ex.Message);
            }
        }

        public async Task<Output<Dropdown>> FetchAllAsync()
        {
            try
            {
                var list = await _supplierRepository.FetchAllAsync();
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

        public async Task<Output<SupplierDetail>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _supplierRepository.GetByIdAsync(id);
                SupplierDetail detail = new()
                {
                    Id = result.Id,
                    Name = result.Name,
                    Address = result.Address,
                    ContactPerson = result.ContactPerson,
                    EmailAddress = result.EmailAddress,
                    PhoneNumber = result.PhoneNumber
                };
                return OutputConverter.SetSuccess([detail]);
            }
            catch(Exception ex)
            {
                return OutputConverter.SetFailed<SupplierDetail>(ex.Message);
            }
        }

        #endregion Read

        #region Write

        public async Task<Output> SaveAsync(SupplierCreate request)
        {
            try
            {
                var result = await _createValidator.ValidateAsync(request);
                if(!result.IsValid)
                {
                    return OutputConverter.SetFailed(result);
                }

                Supplier entity = new()
                {
                    Name = request.Name,
                    ContactPerson = request.ContactPerson,
                    EmailAddress = request.EmailAddress,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address,
                    CreatedBy = request.CreatedBy
                };
                await _supplierRepository.SaveAsync(entity);
                return OutputConverter.SetSuccess($"{_module} {Operation.Save} {Message.Successfully}.");
            }
            catch(Exception ex)
            {
                return OutputConverter.SetFailed(ex.Message);
            }
        }

        public async Task<Output> UpdateAsync(SupplierUpdate request)
        {
            try
            {
                var result = await _updateValidator.ValidateAsync(request);
                if(!result.IsValid)
                {
                    return OutputConverter.SetFailed(result);
                }

                Supplier entity = new()
                {
                    Id = request.Id,
                    Name = request.Name,
                    ContactPerson = request.ContactPerson,
                    EmailAddress = request.EmailAddress,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address,
                    ModifiedBy = request.CreatedBy
                };
                await _supplierRepository.UpdateAsync(entity);
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
                await _supplierRepository.DeleteAsync(id);
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