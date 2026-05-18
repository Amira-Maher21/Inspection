using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.CertificateDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inspection.Techinal.Certificates
{
    public interface ICertificateService
    {
        Task<ReturnBase<CertificateDto>> Create(CertificateCreateDto createDto);
        Task<ReturnBase<CertificateDto>> Update(CertificateUpdateDto updateDto);
        Task<ReturnBase<CertificateDto>> Delete(long id);
        Task<ReturnBase<CertificateDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<CertificateReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}