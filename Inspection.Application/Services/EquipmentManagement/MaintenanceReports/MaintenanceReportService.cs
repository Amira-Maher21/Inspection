using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.MaintenanceReports;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.Equipments;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.MaintenanceReports;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.Equipments;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.MaintenanceReports;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentInspections;
using Inspection.Application.Contracts.Services.EquipmentManagement.MaintenanceReports;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.EquipmentManagement.MaintenanceReports;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Services.EquipmentManagement.MaintenanceReports
{
    internal class MaintenanceReportService : AccountsServiceBase, IMaintenanceReportService
    {
        public MaintenanceReportService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
        }
        private IMaintenanceReportCommandRepository _commands => _accountUoW.MaintenanceReport;
        private IMaintenanceReportQueryRepository _queries => _queriesManager.MaintenanceReport;
        public async Task<List<MaintenanceReportDto>> GetByEquipmentIdAsync(Guid equipmentId)
        {
            var result = await _queries.GetAllAsync();
            var schedules = result.Result
                //.Where(x => x.EquipmentId == equipmentId)
                .ToList();

            return _mapper.Map<List<MaintenanceReport>, List<MaintenanceReportDto>>(schedules);
        }
         
        public async Task<MaintenanceReportDto> CreateAsync(CreateMaintenanceReportDto input)
        {
            var entity = _mapper.Map<CreateMaintenanceReportDto, MaintenanceReport>(input);

            await _commands.InsertAsync(entity);

            return _mapper.Map<MaintenanceReport, MaintenanceReportDto>(entity);
        }
    }
}
