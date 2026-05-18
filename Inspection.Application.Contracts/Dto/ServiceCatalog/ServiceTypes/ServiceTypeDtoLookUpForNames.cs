using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.ServiceCatalog.ServiceTypes
{
    public class ServiceTypeDtoLookUpForNames
    {
        public long Id { get; set; }
        public string Name { get; set; } = default!;
    }
}
