using MarcaModelo.WinForm.Common;
using MarcaModelo.WinForm.Models;

namespace MarcaModelo.WinForm
{
    public class MainViewModelExposer : ViewsModelExposerBase
    {
        public MainViewModelExposer()
        {
            // El "new" del formulario lo gestiona el Exposer
            //Register<EnvioDocumentosAFilialViewModel, FormEnvioDocumentosAFilial>();
            //Register<CierreControladoViewModel, FormCierreControlado>();
            //Register<AutocompleteViewModel, FormAutocomplete>();
            //Register<WaitManejadoPorViewModel, FormWaitManejadoPorViewModel>();
            //Register<NullablesModel, FormNullables>();

            // En caso se necesite se puede registrar con un constructor especifico
            //Register<ErrorExampleViewModel>(x => new FormErrors(x));

            Register<MarcasViewModel, FormMarcas>();
            
            MapReports();
        }

        private void MapReports()
        {
            Register<MarcaReportViewModel, FormPreviewReport>();
            
        }
    }
}