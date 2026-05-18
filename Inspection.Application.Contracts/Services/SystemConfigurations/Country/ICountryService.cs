using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CountrisDto;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.SystemConfigurations.Country
{
    public interface ICountryService
    {
        Task<ReturnBase<CountryDto>> Create(CountryCreateDto createDto);
        Task<ReturnBase<CountryDto>> Update(CountryUpdateDto updateDto);
        Task<ReturnBase<CountryDto>> Delete(long id);
        Task<ReturnBase<CountryDto>> GetById(long id);
        Task<ReturnBase<CountryDto>> GetByCode(String Name);

        Task<ReturnBase<IEnumerable<CountryDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
