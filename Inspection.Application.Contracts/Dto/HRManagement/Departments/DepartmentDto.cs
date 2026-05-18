using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.HRManagement.Departments
{
    public class DepartmentDto 
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

}
