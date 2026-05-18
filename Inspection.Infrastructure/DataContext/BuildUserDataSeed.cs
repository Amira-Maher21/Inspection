using Microsoft.EntityFrameworkCore;

namespace Inspection.Infrastructure.DataContext
{
    public static class BuildUserDataSeed
    {
        public static void BuildMainData(this ModelBuilder modelBuilder)
        {
            #region Users 
            //modelBuilder.Entity<Customer>().HasData(
            //    new
            //    {
            //        Id = 1L,
            //        Name = "Ahmed Yousry",
            //        Code = "CUST001",
            //        Tenant_ID = "saboor",

            //        CountryId = 1L,
            //        CityId = 1L,
            //        CustomerGroupId = 2L,
            //        SeriesId = 24L,

            //        Address = "New Damietta",
            //        Phone = "01007458070",
            //        Mobile = "01007458070",
            //        Email = "ahmedu3helal@gmail.com",

            //        RunningNumber = 1,
            //        Disable = false,
            //        In_User = "seed",
            //        In_Date = new DateTime(2026, 2, 17)
            //    }
            //);
            #endregion
        }
    }
}
