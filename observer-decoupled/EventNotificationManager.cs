using Autofac;
using observer.events;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace observer
{
    class EventNotificationManager : IEventNotificationManager
    {
        private readonly ILifetimeScope container;
        private Dictionary<Type, List<SubInvoker>> eventCache = new Dictionary<Type, List<SubInvoker>>();

        public EventNotificationManager(ILifetimeScope container)
        {
            this.container = container;
            InitEvents();
        }

        public void RegisterSubscriber(Type eventType, Subscriber subscriber)
        {
            Type subType = Type.GetType(subscriber.Interface);
            object actualSubType = container.Resolve(subType);
            MethodInfo method = subType.GetMethod(subscriber.Method);

            ParameterExpression eventTypeExpr = Expression.Parameter(typeof(IEvent), "eventType");
            MethodCallExpression callExpression = Expression.Call(Expression.Constant(actualSubType, subType), method, eventTypeExpr);

            SubInvoker invoker = Expression.Lambda<SubInvoker>(callExpression, new ParameterExpression[] { eventTypeExpr }).Compile();

            eventCache[eventType].Add(invoker);
        }

        public void Notify(IEvent ev)
        {
            foreach (SubInvoker invoker in eventCache[ev.GetType()])
            {
                invoker(ev);
            }
        }

        private void InitEvents()
        {
            eventCache.Add(typeof(WeatherChangedEvent), new List<SubInvoker>());
        }
    }


    public class Subscriber
    {
        public string Interface { get; set; }

        public string Method { get; set; }
    }

    public delegate void SubInvoker(IEvent eventType);
}
