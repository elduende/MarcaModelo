using System;
using MarcaModelo.Services;

namespace MarcaModelo.Data
{
    public class GenericRepositoryFactory : IRepositoryFactory
    {
        private readonly IServiceContainer _container;
        private readonly IServiceStore _serviceStore;

        public GenericRepositoryFactory()
        {
            var simple = new SimpleServiceContainer();
            _container = simple;
            _serviceStore = simple;
        }

        public GenericRepositoryFactory(IServiceContainer container, IServiceStore serviceStore)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            if (serviceStore == null)
            {
                throw new ArgumentNullException(nameof(serviceStore));
            }
            this._container = container;
            this._serviceStore = serviceStore;
        }

        public void RegisterSingleton<T>(Func<GenericRepositoryFactory, T> ctor) where T : class
        {
            _serviceStore.RegisterSingleton(x => ctor(this));
        }

        public void RegisterTransient<T>(Func<GenericRepositoryFactory, T> ctor) where T : class
        {
            _serviceStore.RegisterTransient(x => ctor(this));
        }

        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            var instance = _container.GetInstance<TRepository>();
            if (instance == null)
            {
                throw new ArgumentOutOfRangeException("TRepository", string.Format("El constructor para {0} no fue registrado", typeof(TRepository).FullName));
            }
            return instance;
        }
    }
}
