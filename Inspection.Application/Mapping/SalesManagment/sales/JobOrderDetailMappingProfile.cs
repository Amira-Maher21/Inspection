using AutoMapper;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderDetails;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderF;
using Inspection.Domain.Models.Inspection.Techinal.JobOrder;

namespace Inspection.Application.Mapping.SalesManagment.sales
{

    public class JobOrderDetailMappingProfile : Profile
    {
        public JobOrderDetailMappingProfile()
        {
            CreateMap<JobOrderLine, CreateJobOrderLinesDto>().ReverseMap();
            CreateMap<JobOrderLine, JobOrderLinegGetListDto>().ReverseMap();

            CreateMap<UpdateJobOrderLinesDto, JobOrderLine>().ReverseMap();

            CreateMap<JobOrderLinesDto, JobOrderLine>().ReverseMap();



        }
    }
}

