//using Inspection.Application.Contracts.Event;
//using Inspection.Domain.Event;
//using Microsoft.Extensions.DependencyInjection;

//namespace Inspection.Application.Event
//{

//    public class EventBus : IEventBus
//    {
//        private readonly IServiceProvider _serviceProvider;

//        public EventBus(IServiceProvider serviceProvider)
//        {
//            _serviceProvider = serviceProvider;
//        }

//        public async Task Publish<TEvent>(TEvent @event)
//            where TEvent : IDomainEvent
//        {
//            var handlers = _serviceProvider.GetServices<IEventHandler<TEvent>>();
//            foreach (var handler in handlers)
//            {
//                await handler.Handle(@event);
//            }
//        }
//    }
//}
