using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.CertificateDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inspection.Techinal.Certificates;
using Inspection.Application.Contracts.Services.Inspection.Techinal.Certificates;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inspection.Techinal.Certificates;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inspection.Techinal.Certificates
{
    internal class CertificateService : AccountsServiceBase, ICertificateService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;

        public CertificateService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator, ISeriesService seriesService) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
            _seriesService = seriesService;

        }
        public async Task<ReturnBase<CertificateDto>> Create(CertificateCreateDto createDto)
        {
            try
            {
                // DATE VALIDATION
                var validationResult = ValidateCertificateDates(createDto.IssueDate, createDto.ExpiryDate);

                if (!validationResult.Succeeded)
                    return ReturnBase<CertificateDto>.Fail(validationResult.Errors);

                var entity = _mapper.Map<Certificate>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                const string SCREEN_CODE = "Certificate";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                {
                    return ReturnBase<CertificateDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager);
                }

                entity.SeriesId = series.Id;

                var seriesResult =
                    await _seriesService.GetSeriesCodeWithCustomDateUsingSeriesDetails(
                        series.Id,
                        entity.IssueDate);

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<CertificateDto>.Fail(seriesResult.Errors);

                entity.CerficateNumber =
                    seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];

                entity.RunningNumber =
                    int.Parse(seriesResult.Result["RunningNumber"]);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<CertificateDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<CertificateDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<CertificateDto>(entity);

                return ReturnBase<CertificateDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<CertificateDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<CertificateDto>> Update(CertificateUpdateDto updateDto)
        {
            try
            {
                var entity =
                    await _queriesManager.Certificate.GetById(updateDto.Id);

                if (entity is null)
                {
                    return ReturnBase<CertificateDto>.Fail(new[]
                    {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "Certificate Not Found"
                }
            });
                }

                // DATE VALIDATION
                var validationResult =
                    ValidateCertificateDates(updateDto.IssueDate, updateDto.ExpiryDate);

                if (!validationResult.Succeeded)
                    return ReturnBase<CertificateDto>.Fail(validationResult.Errors);

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<CertificateDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<CertificateDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<CertificateDto>(entity);

                return ReturnBase<CertificateDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<CertificateDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CertificateDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.Certificate.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Certificate Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CertificateDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<CertificateDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<CertificateDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<CertificateDto>(entity);

                return ReturnBase<CertificateDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<CertificateDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<CertificateReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
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

                var getResult = await _queriesManager.Certificate.Search(sqlQueryOptions, tenantId, companyId);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<CertificateReturnSearchDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<CertificateReturnSearchDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CertificateReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CertificateDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.Certificate.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Certificate Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CertificateDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<CertificateDto>(entity);

                return ReturnBase<CertificateDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<CertificateDto>.Fail(ex, _exceptionManager);
            }
        }
        private ReturnBase<bool> ValidateCertificateDates(DateTime issueDate, DateTime expiryDate)
        {
            var errors = new List<ReturnBaseError>();

            // 1️⃣ Issue date validation
            if (issueDate == default)
            {
                errors.Add(new ReturnBaseError
                {
                    Source = "Certificate Validation",
                    ErrorMessage = "Issue date is required."
                });
            }

            // 2️⃣ Expiry must be after issue
            if (expiryDate <= issueDate)
            {
                errors.Add(new ReturnBaseError
                {
                    Source = "Certificate Validation",
                    ErrorMessage = "Expiry date must be greater than issue date."
                });
            }

            // 3️⃣ Optional business rule (recommended)
            if (expiryDate <= DateTime.Now.Date)
            {
                errors.Add(new ReturnBaseError
                {
                    Source = "Certificate Validation",
                    ErrorMessage = "Expiry date must be in the future."
                });
            }

            if (errors.Any())
                return ReturnBase<bool>.Fail(errors);

            return ReturnBase<bool>.Success(true);
        }

        private ICertificateCommandRepository _commands
        {
            get { return _accountUoW.Certificate; }
        }
    }
}