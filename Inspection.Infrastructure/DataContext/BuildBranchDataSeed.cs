using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Microsoft.EntityFrameworkCore;

namespace Inspection.Infrastructure.DataContext
{
    public static class BuildBranchDataSeed
    {
        public static void BuildMainData(this ModelBuilder modelBuilder)
        {
            #region Users 
            modelBuilder.Entity<Branch>().HasData(
                new
                {
                    Id = 1L,
                    Name = "HQ-الفرعالرئيسي",
                    Code = "HQ",
                    Tenant_ID = "saboor",

                    CompanyId = 1L,
                    IsSystem = 1L,




                    Disable = false,
                    In_User = "seed",
                    In_Date = new DateTime(2026, 2, 17)
                }
            );
            #endregion
        }
    }
}
