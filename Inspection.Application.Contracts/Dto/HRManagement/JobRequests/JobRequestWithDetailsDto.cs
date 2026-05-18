using Inspection.Application.Contracts.Dto.HRManagement.ApplicantCVs;
using Inspection.Application.Contracts.Dto.HRManagement.JobAdvertisements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.HRManagement.JobRequests
{
    public class JobRequestWithDetailsDto : JobRequestDto
    {
        public List<JobAdvertisementDto> Advertisements { get; set; } = new();
        public List<ApplicantCVDto> CVs { get; set; } = new();
    }

}
