using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.PR.MasterData.SupplierContacts;
using Inspection.Application.Contracts.Dto.AccountingDtos.PR.MasterData.Suppliers;
using Inspection.Domain.Models.Accounting.PR.MasterData.SupplierContacts;
using Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers;

namespace Inspection.Application.Mapping.Accounting.PR.MasterData.Suppliers
{
    public class SuppliersMappingProfile : Profile
    {
        public SuppliersMappingProfile()
        {


            // Master Table
            CreateMap<Supplier, SuppliersCreateDTOs>().ReverseMap();
            CreateMap<SupplierUdateDTOs, Supplier>().ReverseMap();
            CreateMap<SupplierReturnSearchDto, Supplier>().ReverseMap();
            CreateMap<Supplier, SuppliersDTOs>()
                .ForMember(dest => dest.SupplierContactDTOs, opt => opt.MapFrom(src => src.SupplierContacts));



            // Detail Table (Contacts)
            CreateMap<SupplierContact, SupplierContactCreateDTOs>().ReverseMap();
            CreateMap<SupplierContactUdateDTOs, SupplierContact>().ReverseMap();
            CreateMap<SupplierContact, SupplierContactDTOs>().ReverseMap();




        }
    }
}
