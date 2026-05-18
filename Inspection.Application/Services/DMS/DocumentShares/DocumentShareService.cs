using AutoMapper;
using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentShares;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.DMS.DocumentShares;
using Inspection.Application.Contracts.Services.DMS.DocumentShares;
using Inspection.Application.Contracts.Services.MenuManagement.User_Codes;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Application.Shared.SharedValidaion;
using Inspection.Domain.Models.DMS.DocumentShares;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.DMS.DocumentShares
{

    public class DocumentShareService : AccountsServiceBase, IDocumentShareService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly IUser_CodeServise _User_CodeServise
;

        public DocumentShareService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator,
            IUser_CodeServise User_CodeServise) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
            _User_CodeServise = User_CodeServise;
        }

        public async Task<ReturnBase<DocumentShareDto>> Create(DocumentShareCreateDto dto)
        {
            try
            {
                EmailValidator.Validate(dto.Email);

                var entity = _mapper.Map<DocumentShare>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var userData = _tenantResolver.GetCommonUserData();




                //var userName = userData.UserName;

                //if (string.IsNullOrWhiteSpace(userName))
                //{
                //    return ReturnBase<DocumentShareDto>.Fail(new List<ReturnBaseError>
                //    {
                //        new() { ErrorCode = "401", ErrorMessage = "User not authenticated" }
                //    });
                //}


                //var userResult = await _User_CodeServise.GetByCode(userName);

                //if (!userResult.Succeeded || userResult.Result == null)
                //{
                //    return ReturnBase<DocumentShareDto>.Fail(new List<ReturnBaseError>
                //    {
                //        new() { ErrorCode = "404", ErrorMessage = $"User '{userName}' not found" }
                //    });
                //}

                //if (!long.TryParse(userResult.Result.Id, out long userId))
                //{
                //    return ReturnBase<DocumentShareDto>.Fail(new List<ReturnBaseError>
                //    {
                //        new() { ErrorCode = "500", ErrorMessage = "Invalid user ID format" }
                //    });
                //}
                //entity.SharedById = userId;






                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<DocumentShareDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<DocumentShareDto>.Fail(saveResult.Errors);

                return ReturnBase<DocumentShareDto>.Success(_mapper.Map<DocumentShareDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<DocumentShareDto>.Fail(ex, _exceptionManager);
            }
        }





        public async Task<ReturnBase<DocumentShareDto>> Update(DocumentShareUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.DocumentShare.GetById(dto.Id);
                if (entity is null)
                {
                    return ReturnBase<DocumentShareDto>.Fail(new List<ReturnBaseError>
            {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "Document Share  Not Found"
                }
            });
                }
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(dto, entity);



                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<DocumentShareDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<DocumentShareDto>.Fail(saveResult.Errors);

                return ReturnBase<DocumentShareDto>.Success(_mapper.Map<DocumentShareDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<DocumentShareDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<DocumentShareDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.DocumentShare.GetById(id);
                if (entity is null)
                {
                    return ReturnBase<DocumentShareDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = "Document Share  Not Found" }
            });
                }

                var mappedResult = _mapper.Map<DocumentShareDto>(entity);
                mappedResult.IsActive = true;

                var deleteResult = await _commands.DeleteById(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<DocumentShareDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<DocumentShareDto>.Fail(saveResult.Errors);

                mappedResult.IsActive = false;

                return ReturnBase<DocumentShareDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<DocumentShareDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<DocumentShareDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.DocumentShare.GetById(id);
                if (entity is null)
                {
                    return ReturnBase<DocumentShareDto>.Fail(new List<ReturnBaseError>
            {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "Document Share  Not Found"
                }
            });
                }

                var mappedResult = _mapper.Map<DocumentShareDto>(entity);
                return ReturnBase<DocumentShareDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<DocumentShareDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<DocumentShareDto>>> GetList(SqlQueryOptions? sqlQueryOptions = null)
        {
            try
            {
                var entities = await _queriesManager.DocumentShare.GetList(sqlQueryOptions);
                var mappedResult = _mapper.Map<IEnumerable<DocumentShareDto>>(entities);
                return ReturnBase<IEnumerable<DocumentShareDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DocumentShareDto>>.Fail(ex, _exceptionManager);
            }
        }




        public async Task<ReturnBase<IEnumerable<DocumentShareReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.DocumentShare.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<DocumentShareReturnSearchDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<DocumentShareReturnSearchDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DocumentShareReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }



        private IDocumentShareCommandRepository _commands
    => _accountUoW.IDocumentShare;

    }

}
