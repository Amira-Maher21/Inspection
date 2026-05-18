using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestDetailF;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests.Dashboard;
using Inspection.Domain.Models.InspectionManagement.InspectionRequests;

namespace Inspection.Application.Mapping.InspectionManagement.InspectionRequests
{
    public class InspectionRequestMappingProfile : Profile
    {
        public InspectionRequestMappingProfile()
        {
            //CreateMap<InspectionRequest, CreateInspectionRequestDto>().ReverseMap();
            //CreateMap<UpdateInspectionRequestDto, CreateInspectionRequestDto>().ReverseMap();

            CreateMap<InspectionRequestDtoByInclude, InspectionRequest>().ReverseMap();

            CreateMap<InspectionRequestDtoByInclude, InspectionRequestDto>().ReverseMap();

            CreateMap<InspectionRequestDto, InspectionRequestDtoLookUpForNames>().ReverseMap();
            CreateMap<InspectionRequestDtoByInclude, InspectionRequestDtoLookUpForNames>().ReverseMap();
            CreateMap<InspectionRequestDtoByInclude, InspectionRequestDtoLookUpForRequestDetails>().ReverseMap();
            CreateMap<InspectionRequestDto, InspectionRequestDtoLookUpForRequestDetails>().ReverseMap();
            CreateMap<InspectionRequestDtoLookUpForRequestDetails, InspectionRequest>().ReverseMap();


            // ---------------- READ ----------------
            CreateMap<InspectionRequest, InspectionRequestDto>().ReverseMap();
            CreateMap<InspectionRequestLines, InspectionRequestLinesDto>().ReverseMap();

            // ---------------- CREATE ----------------
            CreateMap<CreateInspectionRequestDto, InspectionRequest>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InspectionRequestLines, opt => opt.Ignore());

            CreateMap<CreateInspectionRequestLinesDto, InspectionRequestLines>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InspectionRequests, opt => opt.Ignore());

            // ---------------- UPDATE ----------------
            CreateMap<UpdateInspectionRequestDto, InspectionRequest>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InspectionRequestLines, opt => opt.Ignore());

            CreateMap<UpdateInspectionRequestLinesDto, InspectionRequestLines>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InspectionRequests, opt => opt.Ignore());



            // ================= Dashboard =================

            CreateMap<InspectionRequest, LatestInspectionRequestDto>()
                .ForMember(dest => dest.CustomerName,
                    opt => opt.MapFrom(src => src.Customers.Name))
                .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(src => src.DocumentStatus.ToString())).ReverseMap();

            CreateMap<InspectionRequest, RequestsByStatusDto>()
                .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(src => src.DocumentStatus.ToString()))
                .ForMember(dest => dest.Count,
                    opt => opt.Ignore()).ReverseMap();



            CreateMap<UpdateInspectionRequestDto, InspectionRequest>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InspectionRequestLines, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<UpdateInspectionRequestLinesDto, InspectionRequestLines>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InspectionRequests, opt => opt.Ignore())
                .ReverseMap();

        }
    }
}
