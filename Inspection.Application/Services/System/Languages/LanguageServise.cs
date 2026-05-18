using AutoMapper;
using Inspection.Application.Contracts.Dto.SystemDto.Languages;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.System.Languages;
using Inspection.Application.Contracts.Services.System.Languages;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.System.Languages;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.System.Languages
{
    public class LanguageServise : AccountsServiceBase, ILanguageServise
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public LanguageServise(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            IExcelTemplateGenerator templateGenerator)
            : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }

        public async Task<ReturnBase<LanguageDto>> Create(LanguageCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<Language>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<LanguageDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<LanguageDto>.Fail(saveResult.Errors);

                return ReturnBase<LanguageDto>.Success(_mapper.Map<LanguageDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<LanguageDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<LanguageDto>> Update(LanguageUpdateDto updateDto)
        {
            try
            {

                var entity = await _queriesManager.LanguageQueryRepository.GetById(updateDto.LocaleCode);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Language Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<LanguageDto>.Fail(listOfErrors);
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);





                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<LanguageDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<LanguageDto>(entity);

                return ReturnBase<LanguageDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<LanguageDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<LanguageDto>> Delete(string LocaleCode)
        {
            try
            {
                var entity = await _queriesManager.LanguageQueryRepository.GetById(LocaleCode);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "City Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<LanguageDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(LocaleCode);

                if (!deleteResult.Succeeded)
                    return ReturnBase<LanguageDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<LanguageDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<LanguageDto>(entity);

                return ReturnBase<LanguageDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<LanguageDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<LanguageDto>> GetById(string localeCode)
        {
            try
            {
                var entity = await _queriesManager.LanguageQueryRepository.GetById(localeCode);

                if (entity is null)
                    return ReturnBase<LanguageDto>.Fail(new List<ReturnBaseError>
                        {
                            new ReturnBaseError
                            {
                                ErrorCode = "404",
                                ErrorMessage = "Language Not Found"
                            }
                        });

                return ReturnBase<LanguageDto>.Success(_mapper.Map<LanguageDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<LanguageDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<LanguageDto>>> GetList(SqlQueryOptions? options = null)
        {
            try
            {
                var entities = await _queriesManager.LanguageQueryRepository.GetList(options);
                return ReturnBase<IEnumerable<LanguageDto>>.Success(
                    _mapper.Map<IEnumerable<LanguageDto>>(entities));
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<LanguageDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<LanguageReturnSearchDto>>> Search(SqlQueryOptions options)
        {
            try
            {
                var result = await _queriesManager.LanguageQueryRepository.Search(options);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<LanguageReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<LanguageReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<LanguageReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        private ILanguageCommandRepository _commands
            => _accountUoW.Languages;
    }
}