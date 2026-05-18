using AutoMapper;
using Inspection.Application.Contracts.Dto.SalesManagment.Setup.SalesPerson;
using Inspection.Domain.Models.SalesManagment.Setup.SalesPersons;

namespace Inspection.Application.Mapping.SalesManagment.Setup.SalesPersons
{
    public class SalesPersonMappingProfile : Profile
    {
        public SalesPersonMappingProfile()
        {
            CreateMap<SalesPersonCreateDto, SalesPerson>()
                .ForMember(dest => dest.User_Code, opt => opt.Ignore()); // ignore navigation

            CreateMap<SalesPerson, SalesPersonDto>().ReverseMap();
            CreateMap<SalesPersonUpdateDto, SalesPerson>()
                .ForMember(dest => dest.User_Code, opt => opt.Ignore());


            //        CreateMap<SalesPersonCreateDto, SalesPerson>()
            //.ForMember(dest => dest.User_Code, opt => opt.Ignore()) // ignore navigation
            //.AfterMap((src, dest) =>
            //{
            //    dest.Tenant_ID = _tenantResolver.GetTenantName(); // set tenant
            //});
            //    }
        }
    }
}