using Inspection.Application.Contracts.Repositories.Command.ApprovalManagement;
using Inspection.Domain.Models.ApprovalManagement;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.ApprovalManagement
{
    internal class ApprovalCommandRepository : CommandRepositoryBase<Approval>, IApprovalCommandRepository
    {
        public ApprovalCommandRepository(DbInspectionContext context,
                                        ITenantResolver tenantResolver,
                                        IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {
            this._entityStructure = new EntityStructure
            {
                Key = ["ID"],

            };
            this._entityStructure.RelatedEntities.Add(new RelatedEntity
            {
                EntityType = typeof(Approval_Delegation),
                Keys = ["ID"],
                NavigationProperty = "Approval_Delegations",
                RelatedEntities = null
            });
            this._entityStructure.RelatedEntities.Add(new RelatedEntity
            {
                EntityType = typeof(Approval_d),
                Keys = ["IDScrAproval", "RecordID"],
                NavigationProperty = "Approval_ds",
                RelatedEntities = null
            });
        }
        public async Task InsertWithDetailsAsync(Approval approval)
        {
            approval.Tenant_ID ??= _tenantResolver.GetTenantName();

            var details = approval.Approval_ds?.ToList() ?? new List<Approval_d>();
            approval.Approval_ds = new List<Approval_d>();

            // sure that screen is exist
            var screenExists = await _context.Set<Screen_Code>()
                .AnyAsync(s => s.Screen_ID == approval.ScreenId);

            if (!screenExists)
                throw new Exception($"Screen '{approval.ScreenId}' not found");

            _context.Set<Approval>().Add(approval);
            await _context.SaveChangesAsync();

            foreach (var d in details)
            {
                d.IDScrAproval = approval.Id;
                d.Tenant_ID = approval.Tenant_ID;
                _context.Set<Approval_d>().Add(d);
            }

            await _context.SaveChangesAsync();
            approval.Approval_ds = details;
        }
        //public async Task<ReturnBase> DeleteApprovalDetailsByIds(List<long> ids)
        //{
        //    var approvalDetails = await _context.Set<Approval_d>()
        //        .Where(x => ids.Contains(x.Id))
        //        .ToListAsync();

        //    _context.Set<Approval_d>().RemoveRange(approvalDetails);

        //    return ReturnBase.Success();
        //}
    }
}