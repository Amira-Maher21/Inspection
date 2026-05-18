using AutoMapper;

using Inspection.Application.Contracts.Dto.InspectionManagement.ServicesItemsF;
using Inspection.Domain.Models.InspectionManagement.ServicesItems;
using Inspection.Domain.Models.MenuManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.InspectionManagement.ServiceItemF
{
    public class ServiceItemMappingProfile : Profile
    {
        public ServiceItemMappingProfile()
        {
            CreateMap<ServiceItem, ServiceItemDto>().ReverseMap();
            CreateMap<ServiceItem, CreateServiceItemDto>().ReverseMap();
            CreateMap<ServiceItem, UpdateServiceItemDto>().ReverseMap();
            CreateMap<ServiceItem, ServiceItemIncludeDto>().ReverseMap();
            CreateMap<ServiceItemLookupDefualtDto, ServiceItemIncludeDto>().ReverseMap();
            CreateMap<ServiceItemLookUpByIdForInspectionRequestDto, ServiceItem>().ReverseMap();
            CreateMap<ServiceItemLookUpByIdForInspectionRequestDto, ServiceItemIncludeDto>().ReverseMap();

        }
    }
}
