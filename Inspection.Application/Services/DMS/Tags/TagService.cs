using AutoMapper;
using Inspection.Application.Contracts.Dto.DMSDTOs.TagDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.DMS.Tags;
using Inspection.Application.Contracts.Services.DMS.Tags;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.DMS.Tags;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.DMS.Tags
{
    internal class TagService : AccountsServiceBase, ITagService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;

        public TagService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator, ISeriesService seriesService) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
            _seriesService = seriesService;

        }
        public async Task<ReturnBase<TagDto>> Create(TagCreateDto createDto)
        {
            try
            {
                var entity = _mapper.Map<Tag>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // Insert
                var insertResult = await _commands.InsertAsync(entity);

                if (!insertResult.Succeeded)
                    return ReturnBase<TagDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<TagDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<TagDto>(entity);

                return ReturnBase<TagDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<TagDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<TagDto>> Update(TagUpdateDto updateDto)
        {
            try
            {
                var entity = await _queriesManager.Tag.GetById(updateDto.Id);

                if (entity is null)
                {
                    return ReturnBase<TagDto>.Fail(new[]
                    {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage =$"Tag with Id '{updateDto.Id}' was not found."
                }
            });
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // Map new values
                _mapper.Map(updateDto, entity);

                // Update
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<TagDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<TagDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<TagDto>(entity);

                return ReturnBase<TagDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<TagDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<TagDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.Tag.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Tag with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<TagDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<TagDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<TagDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<TagDto>(entity);

                return ReturnBase<TagDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<TagDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<TagReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var tenantId = _tenantResolver.GetTenantName();
                var commonData = _tenantResolver.GetCommonUserData();

                long companyId = 2;

                if (commonData?.Company != null)
                {
                    long parsedCompanyId;
                    if (long.TryParse(commonData.Company, out parsedCompanyId))
                    {
                        companyId = parsedCompanyId;
                    }
                }

                var getResult = await _queriesManager.Tag.Search(sqlQueryOptions, tenantId, companyId);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<TagReturnSearchDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<TagReturnSearchDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<TagReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<TagDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.Tag.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Tag with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<TagDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<TagDto>(entity);

                return ReturnBase<TagDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<TagDto>.Fail(ex, _exceptionManager);
            }
        }

        private ITagCommandRepository _commands
        {
            get { return _accountUoW.Tag; }
        }
    }
}