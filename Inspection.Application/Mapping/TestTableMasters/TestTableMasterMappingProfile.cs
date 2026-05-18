using AutoMapper;
using Inspection.Application.Contracts.Dto.TestTableMasters;
using Inspection.Domain.Models.TestTableMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.TestTables
{

    public class TestTableMasterMappingProfile : Profile
    {
        public TestTableMasterMappingProfile()
        {
             CreateMap<CreateTestTableMasterDto, TestTableMaster>().ReverseMap();
             CreateMap<UpdateTestTableMasterDto, TestTableMaster>().ReverseMap();
             CreateMap<TestTableMasterDto, TestTableMasterDtoByInclude>().ReverseMap();
             CreateMap<TestTableMasterDto, TestTableMasterDto>().ReverseMap();
         }
    }
}
