using AutoMapper;
using Inspection.Application.Contracts.Dto.HRManagement.Departments;
using Inspection.Application.Contracts.Dto.HRManagement.Employees;
using Inspection.Domain.Models.HRManagement.Departments;
using Inspection.Domain.Models.HRManagement.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.HRManagement.Departments
{
    public class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<Department, CreateDepartmentDto>().ReverseMap();

            CreateMap<UpdateDepartmentDto, Department>()
                       .ForMember(dest => dest.Id, opt => opt.Ignore())  
                       .ForMember(dest => dest.Tenant_ID, opt => opt.Ignore()).ReverseMap();
            CreateMap<DepartmentDto, Department>().ReverseMap();
            CreateMap<Department, DepartmentDtoLookUpForNames>();



        }
    }
}
