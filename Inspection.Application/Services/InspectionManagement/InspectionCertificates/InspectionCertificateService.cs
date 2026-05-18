using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionCertificates;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionCertificates;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionCertificates;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionCertificates;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.InspectionManagement.InspectionCertificates;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.InspectionManagement.InspectionCertificates
{
    public class InspectionCertificateService : AccountsServiceBase, IInspectionCertificateService
    {
        private readonly ITenantResolver _tenantResolver;

        private IInspectionCertificateCommandRepository _commands => _accountUoW.InspectionCertificate;
        private IInspectionCertificateQueryRepository _queries => _queriesManager.InspectionCertificate;

        public InspectionCertificateService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
        }
        public async Task<ReturnBase<InspectionCertificateUpdateDto>> CreateAsync(InspectionCertificateCreateDto input)
        {
            try
            {
                var entity = _mapper.Map<InspectionCertificate>(input);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var result = await _commands.InsertAsync(entity);
                if (!result.Succeeded)
                    return ReturnBase<InspectionCertificateUpdateDto>.Fail(result.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<InspectionCertificateUpdateDto>.Fail(saveResult.Errors);

                return ReturnBase<InspectionCertificateUpdateDto>.Success(_mapper.Map<InspectionCertificateUpdateDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionCertificateUpdateDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InspectionCertificateUpdateDto>> UpdateAsync(long id, InspectionCertificateUpdateDto input)
        {
            try
            {

                var entity = await _queries.GetByIdAsync(id);
                if (entity == null)
                    return ReturnBase<InspectionCertificateUpdateDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = "Inspection Certificate Not Found" }
            });
                _mapper.Map(input, entity);

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<InspectionCertificateUpdateDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<InspectionCertificateUpdateDto>.Fail(saveResult.Errors);

                return ReturnBase<InspectionCertificateUpdateDto>.Success(_mapper.Map<InspectionCertificateUpdateDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionCertificateUpdateDto>.Fail(ex, _exceptionManager);
            }
        }



        public async Task<ReturnBase<bool>> DeleteAsync(long id)
        {
            try
            {
                var keys = new EntityKeyValueDictionary
            {
                { new KeyValuePair<string, object>("Id", id) }
            };

                var deleteResult = await _commands.DeleteAsync(keys);
                if (!deleteResult.Succeeded)
                    return ReturnBase<bool>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<bool>.Fail(saveResult.Errors);

                return ReturnBase<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ReturnBase<bool>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InspectionCertificateDto>> GetAsync(long id)
        {
            try
            {
                var entity = await _queries.GetByIdAsync(id);
                if (entity == null)
                    return ReturnBase<InspectionCertificateDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "Inspection Certificate Not Found" }
                    });

                return ReturnBase<InspectionCertificateDto>.Success(_mapper.Map<InspectionCertificateDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionCertificateDto>.Fail(ex, _exceptionManager);
            }


        }

        public async Task<ReturnBase<List<InspectionCertificateDto>>> GetListAsync()
        {
            try
            {
                var list = await _queries.GetAllAsync();
                return ReturnBase<List<InspectionCertificateDto>>.Success(
                    _mapper.Map<List<InspectionCertificateDto>>(list.Result)
                );
            }
            catch (Exception ex)
            {
                return ReturnBase<List<InspectionCertificateDto>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<List<InspectionCertificateDtoByInclude>>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var list = await _queries.GetListByIncludeAsync(sqlQueryOptions);

                return ReturnBase<List<InspectionCertificateDtoByInclude>>.Success(_mapper.Map<List<InspectionCertificateDtoByInclude>>(list));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<InspectionCertificateDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }




    }
}