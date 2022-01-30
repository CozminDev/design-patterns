using observer.events;
using System;

namespace observer
{
    public interface IEventNotificationManager
    {
        void RegisterSubscriber(Type eventType, Subscriber subscriber);

        void Notify(IEvent ev);
    }
}