using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionReports;
using Inspection.Domain.Models.InspectionManagement.InspectionReports;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.InspectionManagement.InspectionReports
{
    public class InspectionReportProfile : Profile
    {
        public InspectionReportProfile()
        {
            CreateMap<CreateInspectionReportDto, InspectionReport>();
            CreateMap<UpdateInspectionReportDto, InspectionReport>();
            CreateMap<InspectionReport, InspectionReportDto>();
        }
    }
}
