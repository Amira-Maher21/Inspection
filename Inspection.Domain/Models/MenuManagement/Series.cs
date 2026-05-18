using Inspection.Domain.Enums;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Models.MenuManagement
{
    public class Series : IRootEntity, ITenantEntity
    {
        [Key]
        public long Id { get; set; }
        public string CodePattern { get; set; }
        public int PaddingLength { get; set; }
        //public char Separator { get; set; }
        public ResetPolicyEnum ResetPolicy { get; set; }
        [ForeignKey("ScreenCode")] 
        public string ScreenCode_Id { get; set; }
        public Screen_Code? ScreenCode { get; set; }
        public string Tenant_ID { get; set; }
        public Boolean IsActive { get; set; } = true;

    }
}
