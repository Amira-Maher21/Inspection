using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto
{
    public class DeleteResultDto
    {
        public bool Deleted { get; set; }
        public IEnumerable<ReturnBaseError>? Errors { get; set; }
    }
}
