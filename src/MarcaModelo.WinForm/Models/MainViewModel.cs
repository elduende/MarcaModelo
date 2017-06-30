using System;
using System.Threading;
using MarcaModelo.WinForm.Common;
using MarcaModelo.Data;

namespace MarcaModelo.WinForm.Models
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IViewModelExposer _exposer;

        private string _usuario;
       
        public MainViewModel(IViewModelExposer exposer)
        {
            if (exposer == null)
            {
                throw new ArgumentNullException(nameof(exposer));
            }

            _exposer = exposer;

            CloseCommand = new RelayCommand(() =>
            {
                _cierreControlado = true;
                Close();
            });

            Marcas = new RelayCommand(() => exposer.Expose(new MarcasViewModel(new ViewsModelExposerBase(), new Marca())));
            
            Usuario = Thread.CurrentPrincipal.Identity.Name;
        }

        private bool _cierreControlado;
        public RelayCommand CloseCommand { get; set; }

        public override bool CanClose()
        {
            if (_cierreControlado)
            {
                return true;
            }
            YesNoQuestionViewModel sn = new YesNoQuestionViewModel { Title = "Cerrar", Question = "¿Realmente quiere cerrar HDF.Net?" };
            _exposer.ExposeSync(sn);
            return sn.Accepted;
        }
        
        private static bool UsuarioHabilitadoPara(string casoDeUso)
        {
            return Thread.CurrentPrincipal.IsInRole("Con Permisos");
        }

        public ICommand Marcas { get; }
        
        public string Usuario
        {
            get { return _usuario; }
            set
            {
                if (!Equals(_usuario, value))
                {
                    _usuario = value;
                    Thread.CurrentPrincipal = new Usuario { Name = _usuario };
                    CheckAllMenuActions();
                }
            }
        }

        private void CheckAllMenuActions()
        {
            //Marcas.CheckCanExecute();
        }
    }
}
