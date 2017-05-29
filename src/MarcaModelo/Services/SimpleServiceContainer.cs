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

        private readonly ConcurrentDictionary<string, LifeStyle> _lifeStyles = new ConcurrentDictionary<string, LifeStyle>();
        private readonly Dictionary<string, Func<IServiceContainer, object>> _ctors = new Dictionary<string, Func<IServiceContainer, object>>();
        private readonly ConcurrentDictionary<string, object> _singletons = new ConcurrentDictionary<string, object>();

        public void RegisterSingleton<T>(Func<IServiceContainer, T> ctor) where T : class
        {
            _lifeStyles[KeyForType<T>()] = LifeStyle.Singleton;
            _ctors[KeyForType<T>()] = ctor;
        }

        public void RegisterSingleton<T>(T instance) where T : class
        {
            var keyForType = KeyForType<T>();
            _lifeStyles[keyForType] = LifeStyle.Singleton;
            _singletons[keyForType] = instance;
        }

        public void RegisterTransient<T>(Func<IServiceContainer, T> ctor) where T : class
        {
            _lifeStyles[KeyForType<T>()] = LifeStyle.Transient;
            _ctors[KeyForType<T>()] = ctor;
        }

        public T GetInstance<T>() where T : class
        {
            return (T)GetInstance(typeof(T));
        }

        public object GetInstance(Type type)
        {
            LifeStyle lifeStyle;
            var keyForType = type.FullName;
            if (!_lifeStyles.TryGetValue(keyForType, out lifeStyle))
            {
                return null;
            }
            if (LifeStyle.Transient == lifeStyle)
            {
                var ctorFunc = _ctors[keyForType];
                return ctorFunc(this);
            }
            object sigleInstance;
            if (!_singletons.TryGetValue(keyForType, out sigleInstance))
            {
                var ctorFunc = _ctors[keyForType];
                sigleInstance = ctorFunc(this);
                _singletons[keyForType] = sigleInstance;
            }
            return sigleInstance;
        }

        private string KeyForType<T>()
        {
            return typeof(T).FullName;
        }

        public void Dispose()
        {
            foreach (var disposableSingleton in _singletons
                .Select(x => x.Value as IDisposable)
                .Where(x => x != null))
            {
                disposableSingleton.Dispose();
            }
            _singletons.Clear();
        }
    }
}
