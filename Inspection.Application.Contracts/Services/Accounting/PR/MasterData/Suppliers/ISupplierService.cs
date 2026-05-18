using Inspection.Application.Contracts.Dto.AccountingDtos.PR.MasterData.Suppliers;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.PR.MasterData.Suppliers
{
    public interface ISupplierService
    {
        Task<ReturnBase<SuppliersDTOs>> Create(SuppliersCreateDTOs dto);
        Task<ReturnBase<SuppliersDTOs>> Update(SupplierUdateDTOs dto);
        Task<ReturnBase<SuppliersDTOs>> Delete(long id);

        Task<ReturnBase<SuppliersDTOs>> GetById(long id);

        Task<ReturnBase<IEnumerable<SupplierReturnSearchDto>>> Search(SqlQueryOptions? queryOptions = null);





    }
}
