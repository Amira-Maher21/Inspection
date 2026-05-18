using Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.Customers;
using Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments;
using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.CertificateDTOs;
using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.Checklists;
using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.Checklists.ChecklistLines;
using Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.Certificates;
using Inspection.Domain.Models.Inspection.Techinal.Certificates;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inspection.Techinal.Certificates
{
    public class CertificateQueryRepository : QueryRepositoryBase<Certificate>, ICertificateQueryRepository
    {
        public CertificateQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<Certificate?> GetById(long id)
        {
            return await _context.Set<Certificate>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<CertificateReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions, string tenantId, long companyId)
        {
            try
            {
                var certificates = await _context.Set<Domain.Models.Inspection.Techinal.Certificates.Certificate>()
                .Where(c => c.Tenant_ID == tenantId && c.CompanyId == companyId)
                .Include(c => c.Checklist)
                    .ThenInclude(cl => cl.Equipment)
                        .ThenInclude(e => e.Customer)
                .Include(c => c.Checklist)
                    .ThenInclude(cl => cl.ChecklistLines)
                .ToListAsync();


                var result = certificates.Select(c => new CertificateReturnSearchDto
                {
                    Id = c.Id,
                    Tenant_ID = c.Tenant_ID,
                    CompanyId = c.CompanyId,
                    CerficateNumber = c.CerficateNumber,
                    ChekclistId = c.ChekclistId,
                    IssuedByEmployeeId = c.IssuedByEmployeeId,
                    CertificateType = c.CertificateType,
                    IssueDate = c.IssueDate,
                    Period = c.Period,
                    ExpiryDate = c.ExpiryDate,
                    Remarks = c.Remarks,
                    DocumentStatus = c.DocumentStatus,
                    ApprovalStatus = c.ApprovalStatus,
                    SeriesId = c.SeriesId,
                    RunningNumber = c.RunningNumber,
                    In_User = c.In_User,
                    In_Date = c.In_Date,
                    Mod_User = c.Mod_User,
                    Mod_Date = c.Mod_Date,

                    Checklist = c.Checklist == null ? null : new ChecklistDto
                    {
                        Id = c.Checklist.Id,
                        EquipmentId = c.Checklist.EquipmentId,
                        InspectorId = c.Checklist.InspectorId,
                        ChecklistTemplateId = c.Checklist.ChecklistTemplateId,
                        StandardId = c.Checklist.StandardId,
                        InspectionTypeId = c.Checklist.InspectionTypeId,
                        Status = c.Checklist.Status,
                        Location = c.Checklist.Location,
                        Remarks = c.Checklist.Remarks,
                        InspectionDate = c.Checklist.InspectionDate,
                        CompanyId = c.Checklist.CompanyId,
                        DocStatus = c.Checklist.DocStatus,
                        JoborderId = c.Checklist.JoborderId,
                        JobOrderLineId = c.Checklist.JobOrderLineId,
                        Tenant_ID = c.Checklist.Tenant_ID,
                        In_User = c.Checklist.In_User,
                        In_Date = c.Checklist.In_Date,
                        Mod_User = c.Checklist.Mod_User,
                        Mod_Date = c.Checklist.Mod_Date,
                        ChecklistLines = c.Checklist.ChecklistLines.Select(cl => new ChecklistLineDto
                        {
                            Id = cl.Id,
                            ChecklistId = cl.ChecklistId,
                            Remarks = cl.Remarks,
                            MeasuredValue = cl.MeasuredValue,
                            Status = cl.Status,
                            In_User = cl.In_User,
                            In_Date = cl.In_Date,
                            Mod_User = cl.Mod_User,
                            Mod_Date = cl.Mod_Date
                        }).ToList(),
                        Equipment = c.Checklist.Equipment == null ? null : new EquipmentForCertificateDto
                        {
                            Id = c.Checklist.Equipment.Id,
                            Description = c.Checklist.Equipment.Description,
                            SerialNumber = c.Checklist.Equipment.SerialNumber,
                            EquipmentNo = c.Checklist.Equipment.EquipmentNo,
                            EquipmentTypeId = c.Checklist.Equipment.EquipmentTypeId,
                            CustomerId = c.Checklist.Equipment.CustomerId,
                            Tenant_ID = c.Checklist.Equipment.Tenant_ID,
                            Customer = c.Checklist.Equipment.Customer == null ? null : new CustomerForCertificateDto
                            {
                                Id = c.Checklist.Equipment.Customer.Id,
                                Name = c.Checklist.Equipment.Customer.Name,
                                CustomerType = c.Checklist.Equipment.Customer.CustomerType,
                                Code = c.Checklist.Equipment.Customer.Code,
                                NationalId = c.Checklist.Equipment.Customer.NationalId,
                                TaxRegistrationNo = c.Checklist.Equipment.Customer.TaxRegistrationNo,
                                CommercialRegistryNo = c.Checklist.Equipment.Customer.CommercialRegistryNo,
                                Address = c.Checklist.Equipment.Customer.Address,
                                Phone = c.Checklist.Equipment.Customer.Phone,
                                Mobile = c.Checklist.Equipment.Customer.Mobile,
                                Email = c.Checklist.Equipment.Customer.Email,
                                Website = c.Checklist.Equipment.Customer.Website
                            }
                        }
                    }

                }).ToList();

                return ReturnBase<IEnumerable<CertificateReturnSearchDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CertificateReturnSearchDto>>.Fail(ex, _exceptionManager);
            }

            // var certificateRepository = new CertificateQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager, _context);
            //return await certificateRepository.Query(sqlQueryOptions);
        }

        public IQueryable<Certificate> GetAll()
        {
            return _context.Set<Certificate>().AsQueryable();
        }


    }
}