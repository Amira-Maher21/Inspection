using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionReports;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionReports;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.InspectionManagement.InspectionReports;
using NDS.Shared.Kernel.Exceptions;


namespace Inspection.Application.Services.InspectionManagement.InspectionReports
{
    public class InspectionReportAppService : AccountsServiceBase, IInspectionReportService
    {
        public InspectionReportAppService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
        }


        public async Task<Guid> CreateAsync(CreateInspectionReportDto dto)
        {
            var entity = _mapper.Map<InspectionReport>(dto);
            var result = await _accountUoW.InspectionReport.InsertAsync(entity);
            return result.Result.Id;
        }

        public Task<InspectionReportDto?> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<InspectionReportDto>> GetListAsync()
        {

            var list = await _queriesManager.InspectionReport.GetAllAsync();
            return _mapper.Map<List<InspectionReportDto>>(list);
        }

        //public async Task<InspectionReportDto?> GetByIdAsync(long id)
        //{


        //    var entity = await _accountUoW.InspectionOrder.GetByIdAsync(id);
        //    return entity is null ? null : _mapper.Map<InspectionReportDto>(entity);
        //}
        //public async Task<ReturnBase<UpdateInspectionReportDto>> UpdateInspectionReportAsync(UpdateInspectionReportDto dto)
        //{
        //    try
        //    {
        //        var entity = await _queriesManager.InspectionReport.GetByIdAsync(dto.Id);
        //        if (entity is null)
        //        {
        //            var error = new ReturnBaseError
        //            {
        //                ErrorCode = "404",
        //                ErrorMessage = "Inspection Request Not Found"
        //            };
        //            var listOfErrors = new List<ReturnBaseError>() { error };
        //            return ReturnBase<UpdateInspectionReportDto>.Fail(listOfErrors);
        //        }

        //        if (dto.ReportContent is not null)
        //            entity.ReportUrl = dto.ReportContent;

        //        var updateResult = await _accountUoW.InspectionReport.UpdateAsync(entity);

        //        if (!updateResult.Succeeded)
        //            return ReturnBase<UpdateInspectionReportDto>.Fail(updateResult.Errors);

        //        var saveResult = await _accountUoW.SaveAsync();
        //        if (!saveResult.Succeeded)
        //            return ReturnBase<UpdateInspectionReportDto>.Fail(saveResult.Errors);

        //        var mappedResult = _mapper.Map<UpdateInspectionReportDto>(entity);

        //        return ReturnBase<UpdateInspectionReportDto>.Success(mappedResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<UpdateInspectionReportDto>.Fail(ex, _exceptionManager);
        //    }
        //}
    }
}
