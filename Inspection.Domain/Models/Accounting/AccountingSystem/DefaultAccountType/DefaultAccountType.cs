using Inspection.Domain.Enums;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Domain.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.Accounting.AccountingSystem
{
    [Table("DefaultAccountType")]

    public class DefaultAccountType : IRootEntity
    {
        public long Id { get; private set; }

        public string Code { get; private set; } = string.Empty;
        public string VATOUTPUT { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public EntityType EntityType { get; private set; }
        public string ProgramId { get; private set; } = string.Empty;
        public virtual Program Program { get; private set; } = null!;



    }
}
