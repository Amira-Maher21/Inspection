using AutoMapper;
using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentCommentDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.DMS.DocumentComments;
using Inspection.Application.Contracts.Services.DMS.DocumentComments;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.DMS.DocumentComments;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.DMS.DocumentComments
{
    internal class DocumentCommentService : AccountsServiceBase, IDocumentCommentService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;

        public DocumentCommentService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator, ISeriesService seriesService) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
            _seriesService = seriesService;

        }
        public async Task<ReturnBase<DocumentCommentDto>> Create(DocumentCommentCreateDto createDto)
        {
            try
            {
                // Insert
                var entity = _mapper.Map<DocumentComment>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var insertResult = await _commands.InsertAsync(entity);

                if (!insertResult.Succeeded)
                    return ReturnBase<DocumentCommentDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<DocumentCommentDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<DocumentCommentDto>(entity);

                return ReturnBase<DocumentCommentDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<DocumentCommentDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<DocumentCommentDto>> Update(DocumentCommentUpdateDto updateDto)
        {
            try
            {
                var entity =
                    await _queriesManager.DocumentComment.GetById(updateDto.Id);

                if (entity is null)
                {
                    return ReturnBase<DocumentCommentDto>.Fail(new[]
                    {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage =$"Document Comment with Id '{updateDto.Id}' was not found."
                }
            });
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // Map new values
                _mapper.Map(updateDto, entity);

                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<DocumentCommentDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<DocumentCommentDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<DocumentCommentDto>(entity);

                return ReturnBase<DocumentCommentDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<DocumentCommentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<DocumentCommentDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.DocumentComment.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Document Comment with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<DocumentCommentDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<DocumentCommentDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<DocumentCommentDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<DocumentCommentDto>(entity);

                return ReturnBase<DocumentCommentDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<DocumentCommentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<DocumentCommentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.DocumentComment.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<DocumentCommentReturnSearchDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<DocumentCommentReturnSearchDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DocumentCommentReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<DocumentCommentDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.DocumentComment.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Document Comment with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<DocumentCommentDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<DocumentCommentDto>(entity);

                return ReturnBase<DocumentCommentDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<DocumentCommentDto>.Fail(ex, _exceptionManager);
            }
        }

        private IDocumentCommentCommandRepository _commands
        {
            get { return _accountUoW.DocumentComment; }
        }
    }
}