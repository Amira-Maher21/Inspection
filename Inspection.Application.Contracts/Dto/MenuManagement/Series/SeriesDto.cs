using Inspection.Domain.Enums;
using Inspection.Domain.Models.MenuManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.Series
{
    public class SeriesDto
    {
        public long Id { get; set; }
        public string CodePattern { get; set; }
        public int PaddingLength { get; set; }
        //public char Separator { get; set; }
        public ResetPolicyEnum ResetPolicy { get; set; }
        public string ScreenCode_Id { get; set; }
        public Boolean IsActive { get; set; }

    }

}
