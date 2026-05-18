using Inspection.Domain.Event;

namespace Inspection.Application.Contracts.Event
{
    //public interface IEventHandler<TEvent>
    //{
    //    Task Handle(TEvent @event);
    //}
    public interface IEventHandler<in TEvent>
    where TEvent : IDomainEvent
    {
        Task Handle(TEvent @event);
    }

}
