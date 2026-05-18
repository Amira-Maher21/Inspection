using AutoMapper;
using Inspection.Application.Contracts.Dto.ServiceCatalog.ServiceTypes;
using Inspection.Domain.Models.ServiceCatalog.ServiceTypes;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.ServiceCatalog.ServiceTypes
{
    public class ServiceTypeProfile : Profile
    {
        public ServiceTypeProfile()
        {
            CreateMap<ServiceType, ServiceTypeDto>().ReverseMap();
            CreateMap<CreateServiceTypeDto, ServiceType>().ReverseMap();
            CreateMap<UpdateServiceTypeDto, ServiceType>().ReverseMap();
            CreateMap<ServiceTypeDto, ServiceTypeDtoLookUpForNames>().ReverseMap();
            CreateMap<ServiceTypeDto, ServiceTypeDtoByInclude>().ReverseMap();
            CreateMap<ServiceTypeDtoLookUpForNames, ServiceTypeDtoByInclude>().ReverseMap();

        }
    }

}
