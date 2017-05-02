using MarcaModelo.WinForm.Common;

namespace MarcaModelo.WinForm.Models
{
    public class CierreControladoViewModel : ViewModelBase
    {
        private bool cierreControlado;
        private readonly IViewModelExposer exposer;
        public CierreControladoViewModel(IViewModelExposer exposer)
        {
            this.exposer = exposer;
            CloseCommand = new RelayCommand(() =>
            {
                cierreControlado = true;
                Close();
            });
        }

        public RelayCommand CloseCommand { get; set; }

        public override bool CanClose()
        {
            if (cierreControlado)
            {
                return true;
            }
            var sn = new YesNoQuestionViewModel { Title = "Borrador", Question = "Realmente cerrar ?" };
            exposer.ExposeSync(sn);
            return sn.Accepted;
        }

        protected override void Dispose(bool disposing)
        {
            // Liberar eventuales recursos como procesos en backgroud, subscripciones a eventos de aplicación.. etc.
            base.Dispose(disposing);
        }
    }
}
