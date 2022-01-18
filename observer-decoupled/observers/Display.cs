using observer.events;
using System;

namespace observer.observers
{
    public class Display : IDisplay
    {
        public void Update(IEvent eventType)
        {
            Console.WriteLine(eventType.GetType().FullName);
        }
    }
}
