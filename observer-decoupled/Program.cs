using Autofac;
using observer.events;
using observer.observers;

namespace observer
{
    class Program
    {
        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<Display>().As<IDisplay>();
            builder.RegisterType<EventNotificationManager>().As<IEventNotificationManager>();
            IContainer container = builder.Build();

            IEventNotificationManager eventNotificationManager = container.Resolve<IEventNotificationManager>();

            Subscriber sub = new Subscriber()
            {
                Interface = "observer.observers.IDisplay",
                Method = "Update"
            };

            eventNotificationManager.RegisterSubscriber(typeof(WeatherChangedEvent), sub);

            eventNotificationManager.Notify(new WeatherChangedEvent());
        }
    }
}
