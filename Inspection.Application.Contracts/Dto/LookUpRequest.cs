using NDS.Shared.Application.DataQuery;

namespace Inspection.Application.Contracts.Dto
{
    public class LookUpRequest
    {
        public SqlQueryOptions QueryOptions { get; set; }
        public object[] FunctionParameters { get; set; }
        public List<UserSelectionDto> UserSelections { get; set; }
    }

    public class UserSelectionDto
    {
        public long? UserId { get; set; }
        public string? UserName { get; set; }
    }
}
