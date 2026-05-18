using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentInspections;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentInspections;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentInspections;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentInspections;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.EquipmentManagement.EquipmentInspections;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.EquipmentManagement.EquipmentInspections
{
    internal class EquipmentInspectionService : AccountsServiceBase, IEquipmentInspectionService
    {
        public EquipmentInspectionService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
        }
        private IEquipmentInspectionCommandRepository _commands => _accountUoW.EquipmentInspection;
        private IEquipmentInspectionQueryRepository _queries => _queriesManager.EquipmentInspection;

        public async Task<List<EquipmentInspectionDto>> GetListByEquipmentIdAsync(long equipmentId)
        {
            var list = await _queries.GetListWithDetailsAsync(equipmentId);
            return _mapper.Map<List<EquipmentInspectionWithNavigationPropertiesDto>, List<EquipmentInspectionDto>>(list);
        }





        public async Task<ReturnBase<EquipmentInspectionDto>> GetById(long id)

        {
            try
            {
                var entity = await _queriesManager.EquipmentInspection.GetById(id);
                if (entity is null)
                {
                    return ReturnBase<EquipmentInspectionDto>.Fail(new List<ReturnBaseError>
            {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "Equipment Inspection  Not Found"
                }
            });
                }

                var mappedResult = _mapper.Map<EquipmentInspectionDto>(entity);
                return ReturnBase<EquipmentInspectionDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<EquipmentInspectionDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<EquipmentInspectionDto> CreateAsync(CreateEquipmentInspectionDto input)
        {
            var entity = _mapper.Map<CreateEquipmentInspectionDto, EquipmentInspection>(input);
            await _commands.InsertAsync(entity);
            return _mapper.Map<EquipmentInspection, EquipmentInspectionDto>(entity);
        }

        public Task<List<EquipmentInspectionDto>> GetListByEquipmentIdAsync(Guid equipmentId)
        {
            throw new NotImplementedException();
        }


    }
}
