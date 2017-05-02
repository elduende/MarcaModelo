using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using MarcaModelo.Sistema.Events;

namespace MarcaModelo.Services
{
    public class DomainEventHandlersStore : IDomainEventHandlersStore
    {
        private readonly ConcurrentDictionary<Type, List<Func<object>>> store =
            new ConcurrentDictionary<Type, List<Func<object>>>();

        public IEnumerable<IDomainEventHandler<T>> GetHandlersOf<T>() where T : IDomainEvent
        {
            List<Func<object>> eventHandlersFactories;
            if (store.TryGetValue(typeof(T), out eventHandlersFactories))
            {
                foreach (var func in eventHandlersFactories)
                {
                    yield return (IDomainEventHandler<T>)func();
                }
            }
        }

        public void RegisterHandlerOf<T>(Func<IDomainEventHandler<T>> factory) where T : IDomainEvent
        {
            GetEventHandlersFactoriesFor<T>().Add(factory);
        }

        private List<Func<object>> GetEventHandlersFactoriesFor<T>()
        {
            List<Func<object>> list;
            if (!store.TryGetValue(typeof(T), out list))
            {
                list = new List<Func<object>>();
                store[typeof(T)] = list;
            }
            return list;
        }
    }
}
