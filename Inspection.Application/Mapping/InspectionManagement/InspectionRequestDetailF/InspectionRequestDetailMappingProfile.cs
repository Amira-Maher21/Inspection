using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestDetailF;
  using Inspection.Domain.Models.InspectionManagement.InspectionRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.InspectionManagement.InspectionRequestDetailF
{
 
    public class InspectionRequestDetailMappingProfile : Profile
    {
        public InspectionRequestDetailMappingProfile()
        {
            CreateMap<InspectionRequestLines, CreateInspectionRequestLinesDto>().ReverseMap();

            CreateMap<UpdateInspectionRequestLinesDto, InspectionRequestLines>().ReverseMap();

            CreateMap<InspectionRequestLinesDto, InspectionRequestLines>().ReverseMap();

            //CreateMap<InspectionRequestLinesDtoLookUpForNames, InspectionRequestLines>().ReverseMap();

            CreateMap<InspectionRequestLinesDtoByInclude, InspectionRequestLines>().ReverseMap();
            CreateMap<InspectionRequestLinesDtoByInclude, InspectionRequestLinesDto>().ReverseMap();


            //CreateMap<InspectionRequestLinesDtoByInclude, InspectionRequestLinesDtoLookUpForNames>().ReverseMap();

        }
    }
}
