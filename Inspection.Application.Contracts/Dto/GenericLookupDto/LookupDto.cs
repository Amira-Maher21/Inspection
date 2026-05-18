using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.GenericLookupDto
{
    public class LookupDto<TKey>
    {
        public TKey Id { get; set; }
        public string DisplayName { get; set; }
    }

}
