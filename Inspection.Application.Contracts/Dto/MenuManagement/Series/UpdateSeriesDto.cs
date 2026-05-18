using Inspection.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.Series
{
    public class UpdateSeriesDto
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string CodePattern { get; set; }

        [Required]
        public int PaddingLength { get; set; }

        //[Required]
        //public char Separator { get; set; }

        [Required]
        public ResetPolicyEnum ResetPolicy { get; set; }

        [Required]
        public string ScreenCode_Id { get; set; }
        public Boolean IsActive { get; set; }
    }
}
