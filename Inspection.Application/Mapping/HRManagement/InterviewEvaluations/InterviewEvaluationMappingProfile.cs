using AutoMapper;
using Inspection.Application.Contracts.Dto.HRManagement.InterviewEvaluations;
using Inspection.Domain.Models.HRManagement.InterviewEvaluations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.HRManagement.InterviewEvaluations
{
    public class InterviewEvaluationMappingProfile:Profile
    {
        public InterviewEvaluationMappingProfile()
        {
            CreateMap<InterviewEvaluation, CreateInterviewEvaluationDto>().ReverseMap();

            CreateMap<UpdateInterviewEvaluationDto, InterviewEvaluation>()
                       .ForMember(dest => dest.Id, opt => opt.Ignore())
                       .ForMember(dest => dest.Tenant_ID, opt => opt.Ignore()).ReverseMap();
            CreateMap<InterviewEvaluationDto, InterviewEvaluation>().ReverseMap();
            CreateMap<InterviewEvaluation, InterviewEvaluationDtoLookUpForNames>();



        }
    }
}
