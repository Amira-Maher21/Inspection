using Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesOrder;
using Inspection.Domain.Enums;
using Inspection.Domain.Models.SalesManagment.Transaction.DTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.SalesManagment.sales.SalesOrder
{

    public interface ISalesOrderService : IAccountServiceBase
    {
        Task<ReturnBase<SalesOrderDto>> GetAsync(long id);

        Task<ReturnBase<List<SalesOrderDtoInclude>>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

        Task<ReturnBase<List<SalesOrderLookupDefualtDto>>> SalesOrderLookupDefualt(SqlQueryOptions sqlQueryOptions);



        Task<ReturnBase<List<SalesOrderDto>>> GetListAsync();

        Task<ReturnBase<UpdateSalesOrderDto>> CreateAsync(CreateSalesOrderDto input);

        Task<ReturnBase<UpdateSalesOrderDto>> UpdateAsync(long id, UpdateSalesOrderDto input);

        //Task<ReturnBase<bool>> ChangeStatus(long id, ChangeStatusRequest Status);

        Task<ReturnBase<bool>> DeleteAsync(long id);
        Task<ReturnBase<bool>> ChangeDocumentStatusAsync(ChangeSalesOrderDocumentStatusDto newStatus);

    }
}
