using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CompanyDTOs;
using Inspection.Domain.Models.SystemConfigurations.Companies;
using Microsoft.AspNetCore.Http;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.SystemConfigurations.Companies
{
    public interface ICompanyService /*: IAccountServiceBase */
    {
        Task<ReturnBase<CompanyDto>> Create(CompanyCreateDto createDto);
        Task<ReturnBase<CompanyDto>> Update(CompanyUpdateDto updateDto);
        Task<ReturnBase<CompanyDto>> Delete(long id);
        Task<ReturnBase<CompanyDto>> GetById(long id);
        Task<Company> GetByCode(string code);
        Task<ReturnBase<IEnumerable<CompanyReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<List<CompanyDto>> GetAll();
        Task<ReturnBase<IEnumerable<CompanyIdNameDto>>> GetIdAndName(SqlQueryOptions queryOptions);
        Task<ReturnBase<ImportResultDto>> ImportFromExcel(IFormFile file);
        Task<ReturnBase<ImportResultDto>> ImportCompanies(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();
    }
}