using AutoMapper;
using Inspection.Application.Contracts.Dto.SystemDto.TaxCategorys;
using Inspection.Domain.Models.System.Taxestegories;

namespace Inspection.Application.Mapping.System.TaxCategorys
{
    public class TaxCategoryMappingProfile : Profile
    {
        public TaxCategoryMappingProfile()
        {
            CreateMap<TaxCategory, TaxCategoryCreateDto>().ReverseMap();
            CreateMap<TaxCategory, TaxCategoryDto>().ReverseMap();
            CreateMap<TaxCategory, TaxCategoryUpdateDto>().ReverseMap();
        }
    }
}
