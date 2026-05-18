using AutoMapper;
 using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestSubcontractorDetailF;
using Inspection.Domain.Models.InspectionManagement.InspectionRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.InspectionManagement.InspectionRequestDetailSubcontractorF
{
 
    public class InspectionRequestDetailSubcontractorMappingProfile : Profile
    {
        public InspectionRequestDetailSubcontractorMappingProfile()
        {
            CreateMap<InspectionRequestSubcontractorDetail, CreateInspectionRequestSubcontractorDetailDto>().ReverseMap();

            CreateMap<UpdateInspectionRequestSubcontractorDetailDto, InspectionRequestSubcontractorDetail>().ReverseMap();

            CreateMap<InspectionRequestSubcontractorDetailDto, InspectionRequestSubcontractorDetail>().ReverseMap();

            //CreateMap<InspectionRequestDetailSubcontractorDtoLookUpForNames, InspectionRequestDetailSubcontractor>().ReverseMap();

            CreateMap<InspectionRequestSubcontractorDetailDtoByInclude, InspectionRequestSubcontractorDetail>().ReverseMap();
            CreateMap<InspectionRequestSubcontractorDetailDtoByInclude, InspectionRequestSubcontractorDetailDto>().ReverseMap();


            //CreateMap<InspectionRequestDetailSubcontractorDtoByInclude, InspectionRequestDetailSubcontractorDtoLookUpForNames>().ReverseMap();

        }
    }
}
