using Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoiceLines;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoices;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.AR.SalesInvoices
{
    public interface ISalesInvoiceService
    {
        Task<ReturnBase<SalesInvoiceDto>> Create(SalesInvoiceCreateDto createDto);
        Task<ReturnBase<SalesInvoiceDto>> Update(SalesInvoiceUpdateDto updateDto);
        Task<ReturnBase<SalesInvoiceDto>> Delete(long id);
        Task<ReturnBase<SalesInvoiceDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<SalesInvoiceReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

        Task<ReturnBase<List<SalesInvoiceLineDto>>> GetAllLines();
        Task<ReturnBase<ImportResultDto>> ImportSalesInvoice(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadSalesInvoiceTemplate();



    }
}
