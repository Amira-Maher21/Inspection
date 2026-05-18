using AutoMapper;
using Inspection.Application.Contracts.Dto.TestTableDetails;
using Inspection.Application.Contracts.Dto.TestTableMasters;
using Inspection.Domain.Models.TestTableMasters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.TestTables
{

    public class TestTableDetailMappingProfile : Profile
    {
        public TestTableDetailMappingProfile()
        {
            CreateMap<CreateTestTableDetailDto, TestTableDetail>().ReverseMap();
            CreateMap<UpdateTestTableDetailDto, TestTableDetail>().ReverseMap();
            CreateMap<TestTableDetailDto, TestTableDetail>().ReverseMap();
            CreateMap<TestTableDetailDto, TestTableDetailDtoByInclude>().ReverseMap();
          }
    }
}
