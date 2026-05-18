namespace Inspection.Domain.Event
{
    public interface IPostingEvent : IDomainEvent
    {
        public long DocId { get; }
        public string TenantId { get; }
        public string UserId { get; }
    }
}
