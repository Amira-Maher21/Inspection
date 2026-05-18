using AutoMapper;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.salesOrderLines;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesOrders;

namespace Inspection.Application.Mapping.SalesManagment.sales
{
    public class SalesOrderLineProfile : Profile
    {
        public SalesOrderLineProfile()
        {
            CreateMap<SalesOrderLines, SalesOrderLinesDto>().ReverseMap();
        }
    }
}