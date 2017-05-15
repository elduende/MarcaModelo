using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Transactions;
using MarcaModelo.Data;
using MarcaModelo.Events;
using MarcaModelo.Services;
using MarcaModelo.Sistema.Events;
using MarcaModelo.WinForm.Common;
using MarcaModelo.WinForm.Common.Attributes;
using System.Windows.Forms;

namespace MarcaModelo.WinForm.Models
{
    public class MarcasViewModel : ViewModelBase, IValidatableObject
    {
        private int? idMarca;
        private string descripcion;
        private string estado;

        private bool cierreControlado;
        
        private bool esValido;
        
        private readonly IViewModelExposer exposer;
        private readonly IMarcaRepository marcaRepository;
        // private readonly BindingList<MarcaViewModel> marcas = new BindingList<MarcaViewModel>();
        private BindingList<MarcaViewModel> marcas = new BindingList<MarcaViewModel>();
        private readonly RelayCommand imprimirCommand;
        private readonly RelayCommand confirmarCommand;
        private readonly RelayCommand desactivarCommand;
        private readonly RelayCommand activarCommand;
        private readonly RelayCommand activasCommand;
        private readonly RelayCommand inactivasCommand;

        public MarcasViewModel(IViewModelExposer exposer, IMarcaRepository marcaRepository)
        {
            if (exposer == null)
            {
                throw new ArgumentNullException(nameof(exposer));
            }
            if (marcaRepository == null)
            {
                throw new ArgumentNullException("marcaRepository");
            }
            this.exposer = exposer;
            this.marcaRepository = marcaRepository;
            
            CloseCommand = new RelayCommand(() =>
            {
                cierreControlado = true;
                Close();
            });

            PropertyChanged += (sender, args) => { CheckIsValid(); };

            imprimirCommand = new RelayCommand(Imprimir, () => marcas.Count > 0);
            confirmarCommand = new RelayCommand(() => Persist(), () => EsValido);
            desactivarCommand = new RelayCommand(() => Inactivate(), () => MuestraMarcasActivas);
            inactivasCommand = new RelayCommand(() => RefreshGridInactivas(marcaRepository), () => MuestraMarcasActivas);
            activarCommand = new RelayCommand(() => Activate(), () => !MuestraMarcasActivas);
            activasCommand = new RelayCommand(() => RefreshGrid(marcaRepository), () => !MuestraMarcasActivas);
            
            RefreshGrid(marcaRepository);
        }

        [DisplayName("ID Marca")]
        [ReadOnly(true)]
        [Hidden(true)]
        public int? IDMarca
        {
            get { return idMarca; }
            set { SetProperty(ref idMarca, value, nameof(IDMarca)); }
        }

        [DisplayName("Descripción")]
        [ReadOnly(false)]
        [StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "La Descripción es obligatoria")]
        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                SetProperty(ref descripcion, value, nameof(Descripcion));
                if (!Equals(descripcion, value))
                {
                    descripcion = value;
                    OnPropertyChanged("Descripcion");
                }
            }
        }

        [DisplayName("Estado")]
        [ReadOnly(true)]
        [Hidden(true)]
        public string Estado
        {
            get { return estado; }
            set { SetProperty(ref estado, value, nameof(Estado)); }
        }

        public IList<Modelo> Modelos { get; }
        
        public RelayCommand CloseCommand { get; set; }

        public ICommand ImprimirCommand
        {
            get { return imprimirCommand; }
        }

        public ICommand ConfirmarCommand => confirmarCommand;

        public ICommand DesactivarCommand
        {
            get { return desactivarCommand; }
        }

        public ICommand ActivarCommand
        {
            get { return activarCommand; }
        }

        public ICommand ActivasCommand
        {
            get { return activasCommand; }
        }

        public ICommand InactivasCommand
        {
            get { return inactivasCommand; }
        }

        private bool MuestraMarcasActivas { get; set; }

        //[CMS] - Indicación de Fabio
        //Lo que hace eso es que la propiedad en el model solo se inicializa cuando se pide (es un detalle, no te preocupes)
        //public IEnumerable<MarcaViewModel> Marcas => marcas;
        public IEnumerable<MarcaViewModel> Marcas => marcas ?? (marcas = new BindingList<MarcaViewModel>(marcaRepository.GetMarcas().Select(m => new MarcaViewModel { IDMarca = m.IDMarca, Descripcion = m.Descripcion, Estado = m.Estado }).ToList()));


        public override bool CanClose()
        {
            if (cierreControlado)
            {
                return true;
            }
            var sn = new YesNoQuestionViewModel { Title = "Cerrar", Question = "¿Realmente quiere cerrar el formulario?" };
            exposer.ExposeSync(sn);
            return sn.Accepted;
        }

        protected override void Dispose(bool disposing)
        {
            // Liberar eventuales recursos como procesos en backgroud, subscripciones a eventos de aplicación.. etc.
            base.Dispose(disposing);
        }

        public void Imprimir()
        {
            var marca = new Marca();
            exposer.Expose<MarcaReportViewModel>((m => { m.Marca = marca; m.Initialize(); }));
        }

        public void Persist()
        {
            Marca marca = new Marca();
            marca.IDMarca = IDMarca;
            marca.Descripcion = Descripcion;
            marcaRepository.Persist(marca);
            RefreshGrid(marcaRepository);
        }

        public void Inactivate()
        {
            var sn = new YesNoQuestionViewModel { Title = "Desactivar", Question = string.Format("¿Desea desactivar la marca {0}?", Descripcion) };
            exposer.ExposeSync(sn);
            if (sn.Accepted)
            {
                Marca marca = new Marca();
                marca.Descripcion = Descripcion;
                marcaRepository.Inactivate(IDMarca);
                RefreshGrid(marcaRepository);
            }
        }

        public void Activate()
        {
            var sn = new YesNoQuestionViewModel { Title = "Activar", Question = string.Format("¿Desea activar la marca {0}?", Descripcion) };
            exposer.ExposeSync(sn);
            if (sn.Accepted)
            {
                Marca marca = new Marca();
                marca.Descripcion = Descripcion;
                marcaRepository.Activate(IDMarca);
                RefreshGrid(marcaRepository);
            }
        }

        private void RefreshGrid(IMarcaRepository marcaRepository)
        {
            //[CMS]
            marcas.Clear();
            foreach (var m in marcaRepository.GetMarcas())
            {
                marcas.Add(new MarcaViewModel { IDMarca = m.IDMarca, Descripcion = m.Descripcion, Estado = m.Estado });
            }

            MuestraMarcasActivas = true;
        }

        private void RefreshGridInactivas(IMarcaRepository marcaRepository)
        {
            //[CMS]
            marcas.Clear();
            foreach (var m in marcaRepository.GetMarcas())
            {
                marcas.Add(new MarcaViewModel { IDMarca = m.IDMarca, Descripcion = m.Descripcion, Estado = m.Estado });
            }
            MuestraMarcasActivas = false;
        }

        private void CheckIsValid()
        {
            EsValido = this.IsValid(ValidationContext);
        }

        private bool EsValido
        {
            get { return esValido; }
            set
            {
                if (SetProperty(ref esValido, value, () => EsValido))
                {
                    confirmarCommand.CheckCanExecute();
                }
            }
        }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            if (Descripcion != null)
            {
                if (context.IsForModel())
                {
                    // Validaciones que no se quiere que se refieran a una propiedad especifica
                    //El mensaje queda a la altura del botón Confirmar
                }

                if (context.IsForModelOrForProperty(nameof(Descripcion)) && !string.IsNullOrEmpty(Descripcion) && Descripcion.StartsWith(" "))
                {
                    // Ejemplo: Agrega un error de una propiedad en Validate del objeto
                    yield return new ValidationResult("La Descripción comienza con un espacio en blanco.", new[] { nameof(Descripcion) });
                }

                if (marcas.Where(x => x.Descripcion.ToUpper() == Descripcion.ToUpper()).Count() > 0)
                {
                    yield return new ValidationResult("Ya existe una marca con la misma Descripción.", new[] { nameof(Descripcion) });
                }
            }
        }
    }
}
