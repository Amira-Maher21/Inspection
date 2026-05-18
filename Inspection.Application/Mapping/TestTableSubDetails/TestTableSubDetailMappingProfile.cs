using AutoMapper;
using Inspection.Application.Contracts.Dto.TestTableSubDetail;
using Inspection.Application.Contracts.Dto.TestTableSubDetails;
using Inspection.Domain.Models.TestTableMasters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.TestTables
{

    public class TestTableSubDetailMappingProfile : Profile
    {
        public TestTableSubDetailMappingProfile()
        {
             CreateMap<CreateTestTableSubDetailDto, TestTableSubDetail>().ReverseMap();
             CreateMap<UpdateTestTableSubDetailDto, TestTableSubDetail>().ReverseMap();
             CreateMap<TestTableSubDetailDto, TestTableSubDetail>().ReverseMap();
             CreateMap<TestTableSubDetailDto, TestTableSubDetailDtoByInclude>().ReverseMap();
          }
    }
}
