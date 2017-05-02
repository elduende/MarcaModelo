using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace MarcaModelo.Services
{
    public class SimpleServiceContainer : IServiceContainer, IServiceStore
    {
        private enum LifeStyle
        {
            Singleton,
            Transient
        }

        private readonly ConcurrentDictionary<string, LifeStyle> lifeStyles = new ConcurrentDictionary<string, LifeStyle>();
        private readonly Dictionary<string, Func<IServiceContainer, object>> ctors = new Dictionary<string, Func<IServiceContainer, object>>();
        private readonly ConcurrentDictionary<string, object> singletons = new ConcurrentDictionary<string, object>();

        public void RegisterSingleton<T>(Func<IServiceContainer, T> ctor) where T : class
        {
            lifeStyles[KeyForType<T>()] = LifeStyle.Singleton;
            ctors[KeyForType<T>()] = ctor;
        }

        public void RegisterSingleton<T>(T instance) where T : class
        {
            var keyForType = KeyForType<T>();
            lifeStyles[keyForType] = LifeStyle.Singleton;
            singletons[keyForType] = instance;
        }

        public void RegisterTransient<T>(Func<IServiceContainer, T> ctor) where T : class
        {
            lifeStyles[KeyForType<T>()] = LifeStyle.Transient;
            ctors[KeyForType<T>()] = ctor;
        }

        public T GetInstance<T>() where T : class
        {
            return (T)GetInstance(typeof(T));
        }

        public object GetInstance(Type type)
        {
            LifeStyle lifeStyle;
            var keyForType = type.FullName;
            if (!lifeStyles.TryGetValue(keyForType, out lifeStyle))
            {
                return null;
            }
            if (LifeStyle.Transient == lifeStyle)
            {
                var ctorFunc = ctors[keyForType];
                return ctorFunc(this);
            }
            object sigleInstance;
            if (!singletons.TryGetValue(keyForType, out sigleInstance))
            {
                var ctorFunc = ctors[keyForType];
                sigleInstance = ctorFunc(this);
                singletons[keyForType] = sigleInstance;
            }
            return sigleInstance;
        }

        private string KeyForType<T>()
        {
            return typeof(T).FullName;
        }

        public void Dispose()
        {
            foreach (var disposableSingleton in singletons
                .Select(x => x.Value as IDisposable)
                .Where(x => x != null))
            {
                disposableSingleton.Dispose();
            }
            singletons.Clear();
        }
    }
}
