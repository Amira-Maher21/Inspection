using AutoMapper;
using Inspection.Application.Contracts.Dto.HRManagement.Employees;
using Inspection.Domain.Models.HRManagement.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.HRManagement.Employees
{
    public class EmployeeMappingProfile :Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, CreateEmployeeDto>().ReverseMap();

            CreateMap<UpdateEmployeeDto, Employee>().ReverseMap();

            CreateMap<EmployeeDto, Employee>().ReverseMap();


        }
    }
}
