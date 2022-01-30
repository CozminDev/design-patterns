using observer.events;

namespace observer.observers
{
    interface IDisplay
    {
        void Update(IEvent eventType);
    }
}
