using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesQuotationDTOs;
using Inspection.Domain.Models.SalesManagment.Transaction.DTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.SalesManagment.Transactions.SalesQuotations
{
    public interface ISalesQuotationService
    {
        Task<ReturnBase<SalesQuotationDto>> Create(SalesQuotationCreateDto createDto);
        Task<ReturnBase<SalesQuotationDto>> Update(SalesQuotationUpdateDto updateDto);
        Task<ReturnBase<SalesQuotationDto>> Delete(long id);
        Task<ReturnBase<SalesQuotationDto>> GetById(long id);
        //Task<ReturnBase<List<SalesQuotationDto>>> GetAll();
        Task<ReturnBase<IEnumerable<SalesQuotationReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<bool>> ChangeDocumentStatusAsync(ChangeSalesQuotationDocumentStatusDto newStatus);
    }
}