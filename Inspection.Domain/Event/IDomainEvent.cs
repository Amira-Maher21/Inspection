namespace Inspection.Domain.Event
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}
