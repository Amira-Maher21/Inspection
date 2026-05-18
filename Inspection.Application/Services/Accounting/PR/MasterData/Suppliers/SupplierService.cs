using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.PR.MasterData.Suppliers;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.PR.MasterData.Suppliers;
using Inspection.Application.Contracts.Services.Accounting.PR.MasterData.Suppliers;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Application.Shared.SharedValidaion;
using Inspection.Application.Shared.SharedValidation;
using Inspection.Domain.Models.Accounting.PR.MasterData.SupplierContacts;
using Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers;
using Inspection.Infrastructure.Repositories.Query.Accounting.PR.Master.Suppliers;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System.Net.Mail;

namespace Inspection.Application.Services.Accounting.PR.MasterData.Suppliers
{

    public class SupplierService : AccountsServiceBase, ISupplierService
    {
        private readonly IAccountsQueriesManager _queriesManager;
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;


        public SupplierService(IAccountUnitOfWork accountUoW,
                               IAccountsQueriesManager queriesManager,
                               IMapper mapper,
                               IExceptionManager exceptionManager,
                               ITenantResolver tenantResolver,
                        IExcelTemplateGenerator templateGenerator, ISeriesService seriesService)

            : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _queriesManager = queriesManager ?? throw new ArgumentNullException(nameof(queriesManager));
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
            _seriesService = seriesService;

        }

        private ISupplierQueryRepository ISupplierQueryRepo => _queriesManager.ISupplierQueryRepo
                                                               ?? throw new NullReferenceException("ISupplierQueryRepo is null");

        private ISupplierCommandRepository _commands => _accountUoW.SupplierCommand;




        public static class ValidationHelper
        {
            public static bool IsValidEmail(string? email)
            {
                if (string.IsNullOrWhiteSpace(email))
                    return false;

                try
                {
                    var addr = new MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }
            }
        }



        private List<ReturnBaseError> ValidateEmails(Supplier supplier)
        {
            var errors = new List<ReturnBaseError>();

            if (!string.IsNullOrWhiteSpace(supplier.Email) && !ValidationHelper.IsValidEmail(supplier.Email))
            {
                errors.Add(new ReturnBaseError
                {
                    ErrorCode = "400",
                    ErrorMessage = "Supplier email is invalid"
                });
            }

            if (supplier.SupplierContacts != null && supplier.SupplierContacts.Any())
            {
                for (int i = 0; i < supplier.SupplierContacts.Count; i++)
                {
                    var contact = supplier.SupplierContacts.ElementAt(i);
                    if (!string.IsNullOrWhiteSpace(contact.Email) && !ValidationHelper.IsValidEmail(contact.Email))
                    {
                        errors.Add(new ReturnBaseError
                        {
                            ErrorCode = "400",
                            ErrorMessage = $"SupplierContact[{i}] email is invalid"
                        });
                    }
                }
            }

            return errors;
        }

        public async Task<ReturnBase<SuppliersDTOs>> Create(SuppliersCreateDTOs dto)
        {
            try
            {
                dto.Code.ValidateAsCode();
                dto.Name.ValidateAsName();
                EmailValidator.Validate(dto.Email);

                var entity = _mapper.Map<Supplier>(dto);

                //if (!entity.Type)
                //{
                //    if (string.IsNullOrWhiteSpace(entity.NationId))
                //        return ReturnBase<SuppliersDTOs>.Fail(new List<ReturnBaseError>
                //    {
                //        new() { ErrorCode = "400", ErrorMessage = "National ID is required for Individual supplier" }
                //    });
                //}
                //else
                //{
                //    if (string.IsNullOrWhiteSpace(entity.TaxRegistration) || string.IsNullOrWhiteSpace(entity.CommercialRegistry))
                //        return ReturnBase<SuppliersDTOs>.Fail(new List<ReturnBaseError>
                //    {
                //        new() { ErrorCode = "400", ErrorMessage = "Tax Registration and Commercial Registry are required for Company supplier" }
                //    });
                //}

                // Contacts (Details)
                entity.SupplierContacts = dto.SupplierContactDTOs != null
                    ? _mapper.Map<List<SupplierContact>>(dto.SupplierContactDTOs)
                    : new List<SupplierContact>();
                // Set Tenant
                entity.Tenant_ID = _tenantResolver.GetTenantName();



                // SCREEN CODE
                const string SCREEN_CODE = "Supplier";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                {
                    return ReturnBase<SuppliersDTOs>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager
                    );
                }

                entity.SeriesId = series.Id;

                // Generate series number
                var seriesResult =
                    await _seriesService.GetSeriesCodeWithCustomDateUsingSeriesDetails(
                        series.Id, null
                     );

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<SuppliersDTOs>.Fail(seriesResult.Errors);

                entity.Code =
                    seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];

                entity.RunningNumber =
                    int.Parse(seriesResult.Result["RunningNumber"]);





                // Validate Emails
                var emailErrors = ValidateEmails(entity);
                if (emailErrors.Any())
                    return ReturnBase<SuppliersDTOs>.Fail(emailErrors);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<SuppliersDTOs>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<SuppliersDTOs>.Fail(saveResult.Errors);

                return ReturnBase<SuppliersDTOs>.Success(_mapper.Map<SuppliersDTOs>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<SuppliersDTOs>.Fail(ex, _exceptionManager);
            }
        }





        public async Task<ReturnBase<SuppliersDTOs>> Update(SupplierUdateDTOs dto)
        {
            try
            {
                dto.Code.ValidateAsCode();
                dto.Name.ValidateAsName();
                EmailValidator.Validate(dto.Email);
                var entity = await _queriesManager.ISupplierQueryRepo.GetById(dto.Id);
                if (entity == null)
                    return ReturnBase<SuppliersDTOs>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = "Supplier Not Found" }
            });

                if (!dto.Type && string.IsNullOrWhiteSpace(dto.NationId))
                    return ReturnBase<SuppliersDTOs>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "400", ErrorMessage = "National ID is required for Individual supplier" }
            });

                if (dto.Type && (string.IsNullOrWhiteSpace(dto.TaxRegistration) || string.IsNullOrWhiteSpace(dto.CommercialRegistry)))
                    return ReturnBase<SuppliersDTOs>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "400", ErrorMessage = "Tax Registration and Commercial Registry are required for Company supplier" }
            });


                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(dto, entity);

                var existingContacts = entity.SupplierContacts.ToList();

                if (dto.SupplierContactDTOs == null || !dto.SupplierContactDTOs.Any())
                {
                    await _commands.DeleteSupplierContactsBySupplierId(entity.Id);
                }
                else
                {
                    var dtoContactIds = dto.SupplierContactDTOs
                        .Where(c => c.Id > 0)
                        .Select(c => c.Id)
                        .ToHashSet();

                    foreach (var contactDto in dto.SupplierContactDTOs)
                    {
                        if (contactDto.Id == 0)
                        {
                            var newContact = _mapper.Map<SupplierContact>(contactDto);
                            newContact.SupplierId = entity.Id;
                            entity.SupplierContacts.Add(newContact);
                        }
                        else
                        {
                            var existingContact = existingContacts.FirstOrDefault(c => c.Id == contactDto.Id);
                            if (existingContact != null)
                            {
                                _mapper.Map(contactDto, existingContact);
                            }
                        }
                    }

                    var removedContacts = existingContacts
                        .Where(c => !dtoContactIds.Contains(c.Id))
                        .Select(c => c.Id)
                        .ToList();

                    if (removedContacts.Any())
                    {
                        await _commands.DeleteSupplierContactsByIds(removedContacts);
                    }
                }

                var emailErrors = ValidateEmails(entity);
                if (emailErrors.Any())
                    return ReturnBase<SuppliersDTOs>.Fail(emailErrors);

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<SuppliersDTOs>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<SuppliersDTOs>.Fail(saveResult.Errors);

                return ReturnBase<SuppliersDTOs>.Success(_mapper.Map<SuppliersDTOs>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<SuppliersDTOs>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<SuppliersDTOs>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.ISupplierQueryRepo.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Color Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<SuppliersDTOs>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<SuppliersDTOs>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<SuppliersDTOs>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<SuppliersDTOs>(entity);

                return ReturnBase<SuppliersDTOs>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<SuppliersDTOs>.Fail(ex, _exceptionManager);
            }
        }
        //public async Task<ReturnBase<SuppliersDTOs>> Delete(long id)
        //{
        //    try
        //    {
        //        var supplier = await _queriesManager.ISupplierQueryRepo.GetById(id);

        //        if (supplier == null)
        //        {
        //            return ReturnBase<SuppliersDTOs>.Fail(new List<ReturnBaseError>
        //    {
        //        new() { ErrorCode = "404", ErrorMessage = "Supplier Not Found" }
        //    });
        //        }

        //        var dtoResult = _mapper.Map<SuppliersDTOs>(supplier);
        //        dtoResult.Dsiable = true;

        //        //await _commands.DeleteSupplierContactsBySupplierId(supplier.Id);
        //         await _commands.HardDeleteSupplier(supplier.Id);

        //        var saveResult = await _accountUoW.SaveAsync();
        //        if (!saveResult.Succeeded)
        //        {
        //            dtoResult.Dsiable = false;
        //            return ReturnBase<SuppliersDTOs>.Fail(new List<ReturnBaseError>
        //    {
        //        new() { ErrorCode = "500", ErrorMessage = "Failed to delete supplier" }
        //    });
        //        }

        //        return ReturnBase<SuppliersDTOs>.Success(dtoResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<SuppliersDTOs>.Fail(ex, _exceptionManager);
        //    }
        //}

        public async Task<ReturnBase<SuppliersDTOs>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.ISupplierQueryRepo.GetById(id);
                if (entity == null)
                    return ReturnBase<SuppliersDTOs>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "Supplier Not Found" }
                    });

                return ReturnBase<SuppliersDTOs>.Success(_mapper.Map<SuppliersDTOs>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<SuppliersDTOs>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<SupplierReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.ISupplierQueryRepo.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<SupplierReturnSearchDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<SupplierReturnSearchDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<SupplierReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }
    }
}
