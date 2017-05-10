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
        private bool canInactivate;

        private readonly IViewModelExposer exposer;
        private readonly IMarcaRepository marcaRepository;
        private readonly BindingList<MarcaViewModel> marcas = new BindingList<MarcaViewModel>();
        private readonly RelayCommand imprimirCommand;
        private readonly RelayCommand confirmarCommand;
        private readonly RelayCommand desactivarCommand;

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

            RefreshGrid(marcaRepository);

            imprimirCommand = new RelayCommand(Imprimir, () => marcas.Count > 0);
            
            CloseCommand = new RelayCommand(() =>
            {
                cierreControlado = true;
                Close();
            });

            PropertyChanged += (sender, args) => { CheckIsValid(); };
            confirmarCommand = new RelayCommand(() => Persist(), () => EsValido);
            //[CMS] Implementar pregunta 
            desactivarCommand = new RelayCommand(() => Inactivate(), () => true);
            //desactivarCommand = new RelayCommand(() => Inactivate(), () => CanInactivate);
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
        
        public IEnumerable<MarcaViewModel> Marcas => marcas;

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
            Marca marca = new Marca();
            marca.Descripcion = Descripcion;
            marcaRepository.Inactivate(IDMarca);
            RefreshGrid(marcaRepository);
        }

        private void RefreshGrid(IMarcaRepository marcaRepository)
        {
            //[CMS]
            marcas.Clear();
            foreach (var m in marcaRepository.GetMarcas())
            {
                marcas.Add(new MarcaViewModel { IDMarca = m.IDMarca, Descripcion = m.Descripcion, Estado = m.Estado });
            }
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
        
        private bool CanInactivate
        {
            get { return canInactivate; }
            set
            {
                if (SetProperty(ref canInactivate, value, () => CanInactivate))
                {
                    var sn = new YesNoQuestionViewModel { Title = "Desactivar", Question = "¿Desea desactivar la marca?" };
                    exposer.ExposeSync(sn);
                    canInactivate = sn.Accepted;
                    desactivarCommand.CheckCanExecute();
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
