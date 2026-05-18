using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CityDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.SystemConfigurations.Cities
{
    public interface ICityService
    {
        Task<ReturnBase<CityDto>> Create(CityCreateDto createDto);
        Task<ReturnBase<CityDto>> Update(CityUpdateDto updateDto);
        Task<ReturnBase<CityDto>> Delete(long id);
        Task<ReturnBase<CityDto>> GetById(long id);
        Task<ReturnBase<CityDto>> GetByCode(string code);
        Task<ReturnBase<IEnumerable<CitySearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions);
        //Task<ReturnBase<ImportResultDto>> ImportCities(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();
    }
}