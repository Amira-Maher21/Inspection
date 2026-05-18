using AutoMapper;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderDetails;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderF;
using Inspection.Domain.Models.Inspection.Techinal.JobOrder;

namespace Inspection.Application.Mapping.SalesManagment.sales
{
    public class JobOrderProfile : Profile
    {
        public JobOrderProfile()
        {
            //CreateMap<JobOrder, JobOrderDto>().ReverseMap();
            //CreateMap<JobOrder, CreateJobOrderDto>().ReverseMap();
            //CreateMap<JobOrder, UpdateJobOrderDto>().ReverseMap();
            //CreateMap<JobOrderDtoLookUpForNames, JobOrder>().ReverseMap();
            //CreateMap<JobOrderIncludeDto, JobOrderDtoLookUpForNames>().ReverseMap();
            CreateMap<JobOrder, CreateJobOrderDto>().ReverseMap();

            CreateMap<UpdateJobOrderDto, JobOrder>().ReverseMap();

            CreateMap<JobOrderDto, JobOrder>().ReverseMap();

            CreateMap<JobOrderDtoLookUpForNames, JobOrder>().ReverseMap();

            CreateMap<JobOrderIncludeDto, JobOrder>().ReverseMap();
            CreateMap<JobOrderIncludeDto, JobOrderDto>().ReverseMap();


            CreateMap<JobOrderLine, JobOrderLinesDto>().ReverseMap();



            CreateMap<JobOrderIncludeDto, JobOrderDtoLookUpForNames>().ReverseMap();

        }
    }
}
