using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionCertificates;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.InspectionManagement.InspectionCertificates
{
    public interface IInspectionCertificateService : IAccountServiceBase
    {
        Task<ReturnBase<InspectionCertificateUpdateDto>> CreateAsync(InspectionCertificateCreateDto input);
        Task<ReturnBase<InspectionCertificateUpdateDto>> UpdateAsync(long id, InspectionCertificateUpdateDto input);
        Task<ReturnBase<bool>> DeleteAsync(long id);
        Task<ReturnBase<InspectionCertificateDto>> GetAsync(long id);
        //Task<Customer?> GetById(long id);

        Task<ReturnBase<List<InspectionCertificateDto>>> GetListAsync();
        Task<ReturnBase<List<InspectionCertificateDtoByInclude>>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

    }
}
