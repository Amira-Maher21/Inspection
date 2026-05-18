using Inspection.Domain.Enums;
using Inspection.Domain.Enums.Accounting.PostingEngine;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Microsoft.Identity.Client;
using NDS.Shared.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Models.Accounting.PostingEngine
{
    public class PostingAccountMapping : IRootEntity
    {
        public long Id { get; set; }

        public string PostingKey { get; set; } = string.Empty;

        public string AccountSource { get; set; } = string.Empty;

        // FK
        public long PostingDocumentTypeId { get; set; }
        public PostingDocumentType PostingDocumentType { get; set; } = null!;

        public long? ChartOfAccountId { get; set; }
        public ChartOfAccount? ChartOfAccount { get; set; }

        public Side Side { get; set; }

        public int Priority { get; set; }

        public bool IsInventory { get; set; }
        public QuantityDirectionEnum Direction { get; set; }
    }
}
