using System;
using System.Threading;
using MarcaModelo.WinForm.Common;
using MarcaModelo.Data;

namespace MarcaModelo.WinForm.Models
{
    public class MainViewModel : ViewModelBase
    {
        private string usuario;
       

        public MainViewModel(IViewModelExposer exposer)
        {
            if (exposer == null)
            {
                throw new ArgumentNullException(nameof(exposer));
            }
            Marcas = new RelayCommand(() => exposer.Expose(new MarcasViewModel(new ViewsModelExposerBase(), new Marca())));
            
            Usuario = Thread.CurrentPrincipal.Identity.Name;
        }

        private static bool UsuarioHabilitadoPara(string casoDeUso)
        {
            return Thread.CurrentPrincipal.IsInRole("Con Permisos");
        }

        public ICommand Marcas { get; }
        
        public string Usuario
        {
            get { return usuario; }
            set
            {
                if (!Equals(usuario, value))
                {
                    usuario = value;
                    Thread.CurrentPrincipal = new Usuario { Name = usuario };
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
