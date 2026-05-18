using AutoMapper;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Application.Extensions
{
    internal static class AutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDest> IgnoreAuditFields<TSource, TDest>(this IMappingExpression<TSource, TDest> expression)
        where TDest : IAuditable
        {
            return expression
                .ForMember(dest => dest.In_User, opt => opt.Ignore())
                .ForMember(dest => dest.In_Date, opt => opt.Ignore())
                .ForMember(dest => dest.Mod_User, opt => opt.Ignore())
                .ForMember(dest => dest.Mod_Date, opt => opt.Ignore());
        }

        public static IMappingExpression<TSource, TDest> IgnoreMultiTenantFields<TSource, TDest>(this IMappingExpression<TSource, TDest> expression)
        where TDest : ITenantEntity
        {
            return expression
                .ForMember(dest => dest.Tenant_ID, opt => opt.Ignore());
        }
    }
}