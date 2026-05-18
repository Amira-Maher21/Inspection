using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionReports;
using Inspection.Application.Contracts.Services;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.InspectionManagement.InspectionReports
{
    public interface IInspectionReportService : IAccountServiceBase
    {
        Task<Guid> CreateAsync(CreateInspectionReportDto dto);
        Task<List<InspectionReportDto>> GetListAsync();
        Task<InspectionReportDto?> GetByIdAsync(long id);
        //Task<ReturnBase<UpdateInspectionReportDto>> UpdateInspectionReportAsync(UpdateInspectionReportDto dto);
    }

}
