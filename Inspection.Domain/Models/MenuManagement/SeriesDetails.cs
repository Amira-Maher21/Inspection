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
    public class SeriesDetails : IRootEntity, ITenantEntity
    {
        [Key]
        public long Id { get; set; }
        public string Tenant_ID { get; set; }
        public long SeriesId { get; set; }
        public Series Series { get; set; }
        public int CurrentNumber { get; set; } = 0;
        public int Year { get; set; }
        public int? Month { get; set; }

    }
}
