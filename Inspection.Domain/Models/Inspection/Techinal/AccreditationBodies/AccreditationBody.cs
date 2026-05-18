using Inspection.Domain.Models.SystemConfigurations.Countriess;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inspection.Techinal.AccreditationBodies
{
    public class AccreditationBody : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }
        public string Code { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public string? WebsiteUrl { get; private set; }
        public bool IsInternationallyRecognized { get; private set; }

        public long CountryId { get; private set; }
        public Country Country { get; private set; } = null!;
        public List<AccreditationBodyLine> AccreditationBodyLines { get; set; } = new();

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}