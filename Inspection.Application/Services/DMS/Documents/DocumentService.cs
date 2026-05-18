using AutoMapper;
using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentDTOs;
using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentDTOs.DocumentEntityLinkDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.DMS.Documents;
using Inspection.Application.Contracts.Repositories.Query.DMS.Documents;
using Inspection.Application.Contracts.Services.DMS.Documents;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Enums.DMS.DocumentEnums;
using Inspection.Domain.Models.DMS.Documents;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.DMS.Documents
{
    internal class DocumentService : AccountsServiceBase, IDocumentService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IAccountsQueriesManager _queriesManager;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;


        public DocumentService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            IExcelTemplateGenerator templateGenerator, ISeriesService seriesService) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _queriesManager = queriesManager ?? throw new ArgumentNullException(nameof(queriesManager));
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
            _seriesService = seriesService;

        }

        private IDocumentCommandRepository _commands => _accountUoW.Document;
        private IDocumentEntityLinkCommandRepository _documentEntityLink => _accountUoW.DocumentEntityLink;
        private IDocumentQueryRepository _queries => _queriesManager.Document;


        public async Task<ReturnBase<DocumentDto>> Create(DocumentCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<Document>(dto);

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                //// Last Accessed By (convert string to long safely)
                //var userName = _tenantResolver.GetCommonUserData().UserName;
                //if (long.TryParse(userName, out var userId))
                //{
                //    entity.LastAccessedById = userId;
                //}


                if (dto.DocumentEntityLinks != null && dto.DocumentEntityLinks.Any())
                {
                    entity.DocumentEntityLinks = _mapper.Map<List<DocumentEntityLink>>(dto.DocumentEntityLinks);

                    foreach (var documentEntityLink in entity.DocumentEntityLinks)
                    {
                        documentEntityLink.Document = entity;
                        documentEntityLink.LinkedEntityType = LinkedEntityType.Primary; // FORCE BUSINESS RULE
                    }
                }
                else
                {
                    entity.DocumentEntityLinks = new List<DocumentEntityLink>();
                }

                // TAGS
                if (dto.TagIds?.Any() == true)
                {
                    // Ensure the collection is initialized
                    if (entity.DocumentTags == null)
                    {
                        // If DocumentTags is never null, you can remove this check
                        throw new InvalidOperationException("DocumentTags collection is not initialized.");
                    }
                    // Remove existing tags if needed
                    entity.DocumentTags.Clear();
                    foreach (var tagId in dto.TagIds.Distinct())
                    {
                        entity.DocumentTags.Add(new DocumentTag
                        {
                            TagId = tagId,
                            Document = entity
                        });
                    }
                }

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<DocumentDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (saveResult == null)
                    return ReturnBase<DocumentDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "500", ErrorMessage = "SaveAsync returned null" }
            });

                if (!saveResult.Succeeded)
                    return ReturnBase<DocumentDto>.Fail(
                        saveResult.Errors?.ToList() ??
                        new List<ReturnBaseError>
                        {
                    new() { ErrorCode = "500", ErrorMessage = "Save failed" }
                        });

                return ReturnBase<DocumentDto>.Success(_mapper.Map<DocumentDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<DocumentDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<DocumentEntityLinkDto>> CreateDocumentEntityLink(DocumentEntityLinkCreateWithOutDocumentIdDto createDto)
        {
            try
            {
                var entity = _mapper.Map<DocumentEntityLink>(createDto);

                // FORCE BUSINESS RULE
                entity.LinkedEntityType = LinkedEntityType.Related;

                // Insert
                var insertResult = await _documentEntityLink.InsertAsync(entity);

                if (!insertResult.Succeeded)
                    return ReturnBase<DocumentEntityLinkDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<DocumentEntityLinkDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<DocumentEntityLinkDto>(entity);

                return ReturnBase<DocumentEntityLinkDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<DocumentEntityLinkDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<DocumentDto>> Update(DocumentUpdateDto dto)
        {
            try
            {
                // LOAD AGGREGATE ROOT
                var entity = await _queriesManager.Document.GetById(dto.Id);

                if (entity == null)
                {
                    return ReturnBase<DocumentDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = "Document Not Found" }
            });
                }

                // UPDATE MAIN FIELDS
                _mapper.Map(dto, entity);

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                //// Last Accessed By
                //var userName = _tenantResolver.GetCommonUserData().UserName;
                //if (long.TryParse(userName, out var userId))
                //{
                //    entity.LastAccessedById = userId;
                //}

                // TAGS SYNC (Many-to-Many)
                var existingTags = entity.DocumentTags.ToList();

                if (dto.TagIds == null || !dto.TagIds.Any())
                {
                    entity.DocumentTags.Clear();
                }
                else
                {
                    var dtoTagIds = dto.TagIds.Distinct().ToHashSet();

                    var existingTagIds = existingTags
                        .Select(t => t.TagId)
                        .ToHashSet();

                    // ADD NEW
                    var tagsToAdd = dtoTagIds
                        .Where(id => !existingTagIds.Contains(id));

                    foreach (var tagId in tagsToAdd)
                    {
                        entity.DocumentTags.Add(new DocumentTag
                        {
                            DocumentId = entity.Id,
                            TagId = tagId
                        });
                    }

                    // REMOVE OLD
                    var tagsToRemove = existingTags
                        .Where(t => !dtoTagIds.Contains(t.TagId))
                        .ToList();

                    foreach (var tag in tagsToRemove)
                    {
                        entity.DocumentTags.Remove(tag);
                    }
                }

                // DOCUMENT ENTITY LINKS SYNC
                var existingLinks = entity.DocumentEntityLinks.ToList();

                if (dto.DocumentEntityLinks == null || !dto.DocumentEntityLinks.Any())
                {
                    await _commands.DeleteDocumentEntityLinkByDocumentId(entity.Id);
                }
                else
                {
                    var dtoIds = dto.DocumentEntityLinks
                        .Where(x => x.Id > 0)
                        .Select(x => x.Id)
                        .ToHashSet();

                    foreach (var linkDto in dto.DocumentEntityLinks)
                    {
                        // CREATE
                        if (linkDto.Id == 0)
                        {
                            var newLink = _mapper.Map<DocumentEntityLink>(linkDto);
                            newLink.DocumentId = entity.Id;

                            entity.DocumentEntityLinks.Add(newLink);
                        }
                        else
                        {
                            // UPDATE
                            var existing =
                                existingLinks.FirstOrDefault(x => x.Id == linkDto.Id);

                            if (existing != null)
                                _mapper.Map(linkDto, existing);
                        }
                    }

                    // DELETE REMOVED
                    var removedIds = existingLinks
                        .Where(x => !dtoIds.Contains(x.Id))
                        .Select(x => x.Id)
                        .ToList();

                    if (removedIds.Any())
                        await _commands.DeleteDocumentEntityLinksByIds(removedIds);
                }

                // SAVE
                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<DocumentDto>.Fail(saveResult.Errors);

                return ReturnBase<DocumentDto>
                    .Success(_mapper.Map<DocumentDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<DocumentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<DocumentDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.Document.GetById(id);
                if (entity == null)
                    return ReturnBase<DocumentDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "Document Not Found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<DocumentDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<DocumentDto>.Fail(saveResult.Errors);

                return ReturnBase<DocumentDto>.Success(_mapper.Map<DocumentDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<DocumentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<DocumentDto>> GetById(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);
                if (entity == null)
                    return ReturnBase<DocumentDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "Document Not Found" }
                    });

                return ReturnBase<DocumentDto>.Success(_mapper.Map<DocumentDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<DocumentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<DocumentSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions)
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

                var getResult = await _queriesManager.Document.Search(sqlQueryOptions, tenantId, companyId);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<DocumentSearchReturnDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<DocumentSearchReturnDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DocumentSearchReturnDto>>.Fail(ex, _exceptionManager);
            }
        }

    }
}