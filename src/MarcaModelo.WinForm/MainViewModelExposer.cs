using MarcaModelo.WinForm.Common;
using MarcaModelo.WinForm.Models;

namespace MarcaModelo.WinForm
{
    public class MainViewModelExposer : ViewsModelExposerBase
    {
        public MainViewModelExposer()
        {
            // El "new" del formulario lo gestiona el Exposer
            Register<MarcasViewModel, FormMarcas>();

            // En caso se necesite se puede registrar con un constructor especifico
            //Register<ErrorExampleViewModel>(x => new FormErrors(x));
            
            MapReports();
        }

        private void MapReports()
        {
            Register<MarcaReportViewModel, FormPreviewReport>();
            
        }
    }
}