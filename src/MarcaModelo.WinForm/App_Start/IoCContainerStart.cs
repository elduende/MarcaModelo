using MarcaModelo.Data;
using MarcaModelo.Services;

namespace MarcaModelo.WinForm
{
    public static class IoCContainerStart
    {
        public static void RegisterAllServices(this SimpleServiceContainer store)
        {
            var repoFactory = new GenericRepositoryFactory(store, store);
            store.RegisterSingleton<IRepositoryFactory>(c => repoFactory);
            var reports = new ReportsProvider();
            store.RegisterSingleton<IReportsProvider>(reports);
            store.RegisterSingleton<IReportsStore>(reports);
            RegisterRepositories(repoFactory);
        }

        private static void RegisterRepositories(GenericRepositoryFactory store)
        {
            store.RegisterSingleton<IMarcaRepository>(m => new Marca());
            //[CMS]
            store.RegisterSingleton<IModeloRepository>(m => new Modelo(new Marca()));
        }
    }
}
