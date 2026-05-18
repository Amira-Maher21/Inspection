using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsIssues;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsIssues.GoodsIssueLines;
using Inspection.Domain.Models.Inventory.Transaction.GoodsIssues;
using Inspection.Domain.Models.Inventory.Transaction.GoodsIssues.GoodsIssueLines;

namespace Inspection.Application.Mapping.Inventory.Transaction.GoodsIssues
{
    public class GoodsIssueMappingProfile : Profile
    {
        public GoodsIssueMappingProfile()
        {
            // ================= READ =================
            CreateMap<GoodsIssue, GoodsIssueDto>();
            CreateMap<GoodsIssueLine, GoodsIssueLineDto>();

            // ================= CREATE =================
            CreateMap<GoodsIssueCreateDto, GoodsIssue>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.GoodsIssueLines, opt => opt.Ignore());

            CreateMap<GoodsIssueLineCreateDto, GoodsIssueLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.GoodsIssue, opt => opt.Ignore());

            // ================= UPDATE =================
            CreateMap<GoodsIssueUpdateDto, GoodsIssue>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.GoodsIssueLines, opt => opt.Ignore());

            CreateMap<GoodsIssueLineUpdateDto, GoodsIssueLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.GoodsIssue, opt => opt.Ignore());
        }
    }
}