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


namespace MarcaModelo.WinForm.Models
{
    public class MarcasViewModel : ViewModelBase
    {
        private int idMarca;
        private string descripcion;
        private string estado;

        private bool cierreControlado;
        
        private bool esValido;

        private readonly IViewModelExposer exposer;
        private readonly IMarcaRepository marcaRepository;
        private readonly BindingList<MarcaViewModel> marcas = new BindingList<MarcaViewModel>();
        private readonly RelayCommand imprimirCommand;
        private readonly RelayCommand agregarCommand;
        private readonly RelayCommand confirmarCommand;

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

            //[CMS]
            foreach (var m in marcaRepository.GetMarcas())
            {
                marcas.Add(new MarcaViewModel { IDMarca = m.IDMarca, Descripcion = m.Descripcion, Estado = m.Estado });
            }
            imprimirCommand = new RelayCommand(Imprimir, () => marcas.Count > 0);
            agregarCommand = new RelayCommand(Agregar);
            
            CloseCommand = new RelayCommand(() =>
            {
                cierreControlado = true;
                Close();
            });

            PropertyChanged += (sender, args) => { CheckIsValid(); };
            //confirmarCommand = new RelayCommand(() => Close(), () => EsValido);
            confirmarCommand = new RelayCommand(() => Agregar(), () => EsValido);
        }

        [DisplayName("ID Marca")]
        [ReadOnly(true)]
        [Hidden(true)]
        public int IDMarca
        {
            get { return idMarca; }
            set { SetProperty(ref idMarca, value, nameof(IDMarca)); }
        }

        [DisplayName("Descripción")]
        [ReadOnly(false)]
        [StringLength(100, MinimumLength = 2)]
        [Required(ErrorMessage = "La Descripción es obligatoria")]
        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                if (!Equals(descripcion, value))
                {
                    descripcion = value;
                    OnPropertyChanged("Descripcion");
                    //ResetAnomalias();
                }
                SetProperty(ref descripcion, value, nameof(Descripcion));
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
        public void Add(Modelo modelo)
        {
            throw new NotImplementedException();
        }
        public MarcaViewModel GetById(int IDMarca)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Marca> GetMarcas()
        {
            throw new NotImplementedException();
        }
        public void Persist(Marca marca)
        {
            throw new NotImplementedException();
        }
        public RelayCommand CloseCommand { get; set; }
        public ICommand ImprimirCommand
        {
            get { return imprimirCommand; }
        }

        public ICommand AgregarCommand
        {
            get { return agregarCommand; }
        }

        public IEnumerable<MarcaViewModel> Marcas => marcas;

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

        public void Imprimir()
        {
            var marca = new Marca();
            exposer.Expose<MarcaReportViewModel>((m => { m.Marca = marca; m.Initialize(); }));
        }

        public void Agregar()
        {
            Marca marca = new Marca();
            marca.Descripcion = Descripcion;
            marca.Estado = "A";
            marcaRepository.Persist(marca);
        }

        public void Modificar()
        {
            Marca marca = new Marca();
            marca.Descripcion = Descripcion;
            marca.Estado = "A";
            marcaRepository.Persist(marca);
        }

        public ICommand ConfirmarCommand => confirmarCommand;


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
            if (context.IsForModel())
            {
                // Validaciones que no se quiere que se refieran a una propiedad especifica
                if (Descripcion.ToUpper() == Descripcion)
                {
                    yield return new ValidationResult("La Descipción está en mayúsculas.");
                }
            }

            if (context.IsForModelOrForProperty(nameof(Descripcion)) && !string.IsNullOrEmpty(Descripcion) && Descripcion.StartsWith(" "))
            {
                // Ejemplo: Agrega un error de una propiedad en Validate del objeto
                yield return new ValidationResult("La Descripcion comienza con un espacio.", new[] { nameof(Descripcion) });
            }
            //[CMS]
            //¿Cómo valido que no haya otra marca con esa descripción?
        }
    }
}
