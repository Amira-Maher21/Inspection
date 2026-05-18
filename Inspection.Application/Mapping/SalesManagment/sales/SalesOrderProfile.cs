using AutoMapper;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesOrder;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesOrders;

namespace Inspection.Application.Mapping.SalesManagment.sales
{
    public class SalesOrderProfile : Profile
    {
        public SalesOrderProfile()
        {
            CreateMap<SalesOrder, SalesOrderDto>().ReverseMap();
            CreateMap<SalesOrder, CreateSalesOrderDto>().ReverseMap();
            CreateMap<SalesOrder, UpdateSalesOrderDto>().ReverseMap();
            CreateMap<SalesOrder, SalesOrderDtoInclude>().ReverseMap();
            CreateMap<SalesOrderLookupDefualtDto, SalesOrderDtoInclude>().ReverseMap();
        }
    }
}