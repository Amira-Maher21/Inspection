using Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments;
using Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments.EquipmentNew;
using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.ChecklistTemplates;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.Equipments;
using Inspection.Domain.Models.EquipmentManagement.Equipments;
using Inspection.Domain.Models.Inspection.Techinal.ChecklistTemplates;
using Inspection.Infrastructure.QueryObjects.EquipmentManagment.Equipments;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.EquipmentManagement.Equipments
{
    public class EquipmentQueryRepository : QueryRepositoryBase<Equipment>, IEquipmentQueryRepository
    {
        public EquipmentQueryRepository(ISqlQueryBuilder sqlQueryBuilder, DapperDbContext dapperDbContext, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
        }


        public async Task<Equipment?> GetByIdAsync(long id)
        {
            return await _dbSet
                .Include(x => x.EquipmentType)
                .Include(x => x.Customer)
                .Include(x => x.CustomerProject)
                .Include(x => x.CustomerLocation)
                .FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<ReturnBase<IEnumerable<EquipmentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var TaxQueryRepository = new EquipmentsQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await TaxQueryRepository.Query(sqlQueryOptions);
        }
        #region
        public async Task<object?> GetEquipmentByIdAsync(long id)
        {
            var result = await _context.Set<Equipment>()
                .Where(x => x.Id == id)
                .Select(x => new
                {
                    x.Id,
                    x.CompanyId,
                    x.EquipmentNo,
                    x.Description,
                    x.SerialNumber,
                    x.Model,
                    x.Manufacturer,
                    x.ManufactureDate,
                    x.NextInspectionDate,
                    x.Capacity,
                    x.PowerRating,
                    x.Voltage,
                    x.Pressure,
                    x.Dimensions,
                    x.Weight,
                    x.Material,
                    //x.Notes,
                    Detail = x.EquipmentsMoreInformationDetail
                                .Where(d => !string.IsNullOrWhiteSpace(d.KeyValue))
                                .Select(d => new
                                {
                                    d.Id,
                                    d.KeyName,
                                    d.KeyValue
                                })
                                .FirstOrDefault()
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (result == null)
                return null;

            var dictionary = result.GetType()
               .GetProperties()
               .Where(p => p.GetValue(result) != null)
               .ToDictionary(
                   p => p.Name,
                   p =>
                   {
                       if (p.Name == "Detail" && p.GetValue(result) != null)
                       {
                           var detailProps = p.GetValue(result)!.GetType().GetProperties()
                               .ToDictionary(dp => dp.Name, dp => dp.GetValue(p.GetValue(result)));
                           return detailProps;
                       }
                       return p.GetValue(result);
                   });

            var flatDictionary = new Dictionary<string, object?>();
            foreach (var kv in dictionary)
            {
                if (kv.Key == "Detail" && kv.Value is Dictionary<string, object?> innerDict)
                {
                    if (innerDict.TryGetValue("KeyName", out var keyNameObj) && keyNameObj != null &&
                        innerDict.TryGetValue("KeyValue", out var keyValue))
                    {
                        var keyName = keyNameObj.ToString()!;
                        if (!flatDictionary.ContainsKey(keyName))
                        {
                            flatDictionary[keyName] = keyValue;
                        }
                    }
                }
                else
                {
                    flatDictionary[kv.Key] = kv.Value;
                }
            }


            return flatDictionary;
        }



        #endregion


        #region

        public async Task<ReturnBase<EquipmentWithChecklistTemplateDto>> GetChecklistTemplateByEquipmentAsync(long equipmentId, string TanentId, long CompanyId)
        {
            try
            {
                var equipment = await _context.Set<Equipment>()
                   .Include(x => x.EquipmentType)
                   .AsNoTracking()
                   .FirstOrDefaultAsync(x => x.Id == equipmentId);

                if (equipment == null)
                {
                    return ReturnBase<EquipmentWithChecklistTemplateDto>.Fail(
                        new List<ReturnBaseError>
                        {
                    new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Equipment not found"
                    }
                        });
                }

                var template = await _context.Set<ChecklistTemplate>()
                   .Where(x =>
                   x.EquipmentTypeId == equipment.EquipmentTypeId &&
                   x.CompanyId == CompanyId &&
                   x.Tenant_ID == TanentId &&
                   !x.Disabled)
                       .Include(x => x.ChecklistTemplateLines)
                       .OrderByDescending(x => x.Version)
                       .FirstOrDefaultAsync();


                if (template != null)
                {
                    var lines = template.ChecklistTemplateLines;
                }


                if (template == null)
                {
                    return ReturnBase<EquipmentWithChecklistTemplateDto>.Fail(
                        new List<ReturnBaseError>
                        {
                    new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Checklist template not found"
                    }
                        });
                }

                var result = new EquipmentWithChecklistTemplateDto
                {
                    Id = equipment.Id,
                    Description = equipment.Description,
                    SerialNumber = equipment.SerialNumber,
                    EquipmentNo = equipment.EquipmentNo,
                    Notes = equipment.Notes,


                    EquipmentTypeId = equipment.EquipmentTypeId,
                    EquipmentTypes = equipment.EquipmentType,

                    CustomerId = equipment.CustomerId,
                    Customers = equipment.Customer,

                    Tenant_ID = equipment.Tenant_ID,
                    SeriesId = equipment.SeriesId,

                    ChecklistTemplate = new List<ChecklistTemplateDto>
            {
                new ChecklistTemplateDto
                {
                    Id = template.Id,
                    Name = template.Name,
                    Version = template.Version,
                    EquipmentTypeId = template.EquipmentTypeId,
                    StandardId = template.StandardId,
                    ChecklistTemplateNumber = template.ChecklistTemplateNumber,
                    RunningNumber = template.RunningNumber,
                    Disabled = template.Disabled,
                    ChecklistTemplateLines = template.ChecklistTemplateLines
                        .OrderBy(x => x.DisplayOrder)
                        .Select(l => new ChecklistTempleteLineDto
                        {
                            Id = l.Id,
                            ChecklistTemplateId = l.ChecklistTemplateId,
                            DisplayOrder = l.DisplayOrder,
                            SectionName = l.SectionName,
                            ItemText = l.ItemText,
                            In_User = l.In_User,
                            In_Date = l.In_Date,
                            Mod_User = l.Mod_User,
                            Mod_Date = l.Mod_Date,
                            Tenant_ID = l.Tenant_ID
                        })
                        .ToList()
                }
            }
                };

                return ReturnBase<EquipmentWithChecklistTemplateDto>.Success(result);
            }
            catch (Exception ex)
            {
                return ReturnBase<EquipmentWithChecklistTemplateDto>.Fail(ex, _exceptionManager);
            }
        }




        #endregion
    }
}
