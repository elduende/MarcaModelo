using MarcaModelo.Data;
using MarcaModelo.Services;
using MarcaModelo.WinForm.Common;
using MarcaModelo.WinForm.Models;


namespace MarcaModelo.WinForm
{
    public static class ViewModelsConfig
    {
        public static void RegisterApplicationViewModels(this IServiceStore store, IServiceContainer container)
        {
            var appViewmodelsExposer = new MainViewModelExposer();
            appViewmodelsExposer.UseViewModelsFactory(t => container.GetInstance(t) as ViewModelBase); // <== si no está registrado directamente usa el IoC para obtener una instancia del viewmodel

            store.RegisterSingleton<IViewModelExposer>(appViewmodelsExposer);

            RegisterViewModels(store);
            RegisterReports(store);
        }

        private static void RegisterViewModels(IServiceStore store)
        {
            // Cuando se pida de exponer EnvioDocumentosAFilialViewModel se termina ejecutando este metodo
            //store.RegisterTransient(c => new MarcaViewModel(
            //    c.GetInstance<IViewModelExposer>()
            //    , c.GetInstance<IMarcaRepository>()
            //    , c.GetInstance<IModeloRepository>()));
            //store.RegisterTransient(c => new MarcaViewModel());
            store.RegisterTransient(c => new MarcaViewModel(c.GetInstance<IMarcaRepository>()));
            store.RegisterTransient(c => new ModeloViewModel());
        }

        private static void RegisterReports(IServiceStore store)
        {
            store.RegisterTransient(c => new MarcaReportViewModel(c.GetInstance<IReportsProvider>()));
        }
    }
}
