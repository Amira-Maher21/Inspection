using Inspection.Application.Contracts.Dto.AccountingDtos.PR.PurchaseInvoices;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.PR.PurchaseInvoices
{
    public interface IPurchaseInvoiceService
    {
        Task<ReturnBase<PurchaseInvoiceDto>> Create(PurchaseInvoiceCreateDto createDto);
        Task<ReturnBase<PurchaseInvoiceDto>> Update(PurchaseInvoiceUpdateDto updateDto);
        Task<ReturnBase<PurchaseInvoiceDto>> Delete(long id);
        Task<ReturnBase<PurchaseInvoiceDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<PurchaseInvoiceReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

        Task<ReturnBase<ImportResultDto>> ImportPurchaseInvoice(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadPurchaseInvoiceTemplate();
    }
}