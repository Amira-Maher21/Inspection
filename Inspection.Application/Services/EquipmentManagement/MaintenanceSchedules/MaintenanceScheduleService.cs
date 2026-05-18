using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.MaintenanceSchedules;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.MaintenanceSchedules;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.MaintenanceSchedules;
using Inspection.Application.Contracts.Services.EquipmentManagement.MaintenanceSchedules;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.EquipmentManagement.MaintenanceSchedules;
using NDS.Shared.Kernel.Exceptions;


namespace Inspection.Application.Services.EquipmentManagement.MaintenanceSchedules
{
    internal class MaintenanceScheduleService : AccountsServiceBase, IMaintenanceScheduleService
    {
        public MaintenanceScheduleService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
        }
        private IMaintenanceScheduleCommandRepository _commands => _accountUoW.MaintenanceSchedule;
        private IMaintenanceScheduleQueryRepository _queries => _queriesManager.MaintenanceSchedule;
        public async Task<List<MaintenanceScheduleDto>> GetUpcomingAsync(DateTime fromDate)
        {
            var result = await _queries.GetAllAsync();
            var schedules = result.Result
                .Where(x => x.ScheduledDate >= fromDate)
                .ToList();

            return _mapper.Map<List<MaintenanceSchedule>, List<MaintenanceScheduleDto>>(schedules);
        }


        public async Task<MaintenanceScheduleDto> CreateAsync(CreateMaintenanceScheduleDto input)
        {
            var entity = _mapper.Map<CreateMaintenanceScheduleDto, MaintenanceSchedule>(input);

            await _commands.InsertAsync(entity);

            return _mapper.Map<MaintenanceSchedule, MaintenanceScheduleDto>(entity);
        }
    }
}
