using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using MarcaModelo.Data;
using MarcaModelo.WinForm.Common;
using MarcaModelo.WinForm.Common.Attributes;

namespace MarcaModelo.WinForm.Models
{
    public class MarcasViewModel : ViewModelBase, IValidatableObject
    {
        private readonly IViewModelExposer _exposer;
        private readonly IMarcaRepository _marcaRepository;

        public MarcasViewModel(IViewModelExposer exposer, IMarcaRepository marcaRepository)
        {
            if (exposer == null)
            {
                throw new ArgumentNullException(nameof(exposer));
            }
            if (marcaRepository == null)
            {
                throw new ArgumentNullException(nameof(marcaRepository));
            }
            _exposer = exposer;
            _marcaRepository = marcaRepository;
            
            CloseCommand = new RelayCommand(() =>
            {
                _cierreControlado = true;
                Close();
            });

            PropertyChanged += (sender, args) => { CheckIsValid(); };

            _confirmarCommand = new RelayCommand(Persist, () => EsValido);
            _activasCommand = new RelayCommand(() => RefreshMarcas(Enums.EstadoRegistros.Habilitados), () => !EsMarcaActiva);
            _inactivasCommand = new RelayCommand(() => RefreshMarcas(Enums.EstadoRegistros.Inhabilitados), () => EsMarcaActiva);
            _activarCommand = new RelayCommand(Activate, () => !EsMarcaActiva && (string.IsNullOrEmpty(Descripcion) ? "" : Descripcion) != "");
            _desactivarCommand = new RelayCommand(Inactivate, () => EsMarcaActiva && (string.IsNullOrEmpty(Descripcion) ? "" : Descripcion) != "");
            _imprimirCommand = new RelayCommand(Imprimir, () => _marcas.Count > 0);
            _excelCommand = new RelayCommand(Excel, () => _marcas.Count > 0);
            _agregarCommand = new RelayCommand(Agregar, () => PuedeAgregar);
        }

        #region ModelViews
        #region Marca
        private int _idMarca;
        private string _descripcion;
        private string _estado;
        
        [DisplayName("ID Marca")]
        [ReadOnly(true)]
        [Hidden]
        public int IdMarca
        {
            get => _idMarca;
            set => SetProperty(ref _idMarca, value, nameof(IdMarca));
        }

        [DisplayName("Descripción")]
        [ReadOnly(false)]
        [StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "La Descripción es obligatoria")]
        public string Descripcion
        {
            get => _descripcion;
            set
            {
                SetProperty(ref _descripcion, value, nameof(Descripcion));
                if (!Equals(_descripcion, value))
                {
                    _descripcion = value;
                    OnPropertyChanged("Descripcion");
                }
                _desactivarCommand.CheckCanExecute();
                _activarCommand.CheckCanExecute();
                _confirmarCommand.CheckCanExecute();
            }
        }

        [DisplayName("Estado")]
        [ReadOnly(true)]
        [Hidden]
        public string Estado
        {
            get { return _estado; }
            set { SetProperty(ref _estado, value, nameof(Estado)); }
        }
        #endregion
        #endregion

        #region Activar
        private readonly RelayCommand _activarCommand;
        public ICommand ActivarCommand => _activarCommand;

        public void Activate()
        {
            YesNoQuestionViewModel sn = new YesNoQuestionViewModel
            {
                Title = "Activar",
                Question =
                    $"¿Desea activar la marca {Descripcion}?"
            };
            _exposer.ExposeSync(sn);
            if (sn.Accepted)
            {
                _marcaRepository.Activate(IdMarca);
                RefreshMarcas(Enums.EstadoRegistros.Inhabilitados);
            }
        }
        #endregion

        #region Activas
        private readonly RelayCommand _activasCommand;
        public ICommand ActivasCommand => _activasCommand;
        #endregion

        #region Agregar
        private readonly RelayCommand _agregarCommand;
        public ICommand AgregarCommand => _agregarCommand;

        public void Agregar()
        {
            IdMarca = 0;
            Descripcion = null;
            Estado = Enums.EstadoRegistrosDb.Habilitados.ToString();
        }
        #endregion

        #region Buscar
        private string _buscar = "";

        public string Buscar
        {
            get { return _buscar; }
            set
            {
                if (SetProperty(ref _buscar, value))
                {
                    RefreshMarcas(EsMarcaActiva ? Enums.EstadoRegistros.Habilitados : Enums.EstadoRegistros.Inhabilitados);
                }
            }
        }
        #endregion

        #region Cerrar
        private bool _cierreControlado;
        public RelayCommand CloseCommand { get; set; }
        #endregion

        #region Confirmar
        private readonly RelayCommand _confirmarCommand;
        public ICommand ConfirmarCommand => _confirmarCommand;
        #endregion

        #region Control
        public override bool CanClose()
        {
            if (_cierreControlado)
            {
                return true;
            }
            YesNoQuestionViewModel sn = new YesNoQuestionViewModel { Title = "Cerrar", Question = "¿Realmente quiere cerrar el formulario?" };
            _exposer.ExposeSync(sn);
            return sn.Accepted;
        }

        private void CheckIsValid()
        {
            EsValido = this.IsValid(ValidationContext);
        }
        
        private bool _esMarcaActiva;
        public bool EsMarcaActiva
        {
            get { return _esMarcaActiva; }
            set
            {
                if (SetProperty(ref _esMarcaActiva, value, () => EsMarcaActiva))
                {
                    _inactivasCommand.CheckCanExecute();
                    _activasCommand.CheckCanExecute();
                    _desactivarCommand.CheckCanExecute();
                    _activarCommand.CheckCanExecute();
                    _agregarCommand.CheckCanExecute();
                }
                _imprimirCommand.CheckCanExecute();
                _excelCommand.CheckCanExecute();
            }
        }

        private bool _esValido;
        private bool EsValido
        {
            get => _esValido;
            set
            {
                if (SetProperty(ref _esValido, value, () => EsValido))
                {
                    _confirmarCommand.CheckCanExecute();
                }
            }
        }

        private bool _puedeAgregar;
        private bool PuedeAgregar
        {
            get
            {
                _puedeAgregar = EsMarcaActiva;
                return _puedeAgregar;
            }
            set
            {
                if (SetProperty(ref _puedeAgregar, value, () => PuedeAgregar))
                {
                    _agregarCommand.CheckCanExecute();
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

                if (_marcasCompleta.Any(x => string.Equals(x.Descripcion, Descripcion, StringComparison.CurrentCultureIgnoreCase) && x.IdMarca != IdMarca))
                {
                    yield return new ValidationResult("Ya existe una marca con la misma Descripción.", new[] { nameof(Descripcion) });
                }

                if (Descripcion.Length < 2)
                {
                    yield return new ValidationResult("La Descripción no debe ser inferior a dos caracteres.", new[] { nameof(Descripcion) });
                }

                if (Descripcion.Length > 50)
                {
                    yield return new ValidationResult("La Descripción no debe superar los 50 caracteres.", new[] { nameof(Descripcion) });
                }

            }
        }
        #endregion

        #region Desactivar
        private readonly RelayCommand _desactivarCommand;
        public ICommand DesactivarCommand => _desactivarCommand;

        public void Inactivate()
        {
            var sn = new YesNoQuestionViewModel
            {
                Title = "Desactivar",
                Question =
                    $"¿Desea desactivar la marca {Descripcion}?"
            };
            _exposer.ExposeSync(sn);
            if (!sn.Accepted) return;
            _marcaRepository.Inactivate(IdMarca);
            RefreshMarcas(Enums.EstadoRegistros.Habilitados);
        }
        #endregion

        #region Excel
        private readonly RelayCommand _excelCommand;
        public ICommand ExcelCommand => _excelCommand;

        public void Excel()
        {
            var sfd = new SaveFileDialog { Filter = @"csv files (*.csv)|*.csv" };
            if (sfd.ShowDialog() != DialogResult.OK || sfd.FileName.Length <= 0) return;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8);

                var mvm = new MarcaViewModel(null);
                foreach (var propInfo in mvm.GetType().GetProperties())
                {
                    if (propInfo.DeclaringType != null && propInfo.DeclaringType.Name == mvm.GetType().Name)
                    {
                        if (propInfo.CustomAttributes.Any(t => t.AttributeType.Name == "DisplayNameAttribute"))
                        {
                            var myAttribute = (DisplayNameAttribute)Attribute.GetCustomAttribute(propInfo, typeof(DisplayNameAttribute));
                            sw.Write(myAttribute.DisplayName);
                            sw.Write("\t");
                        }
                    }
                }
                sw.Write(sw.NewLine);

                foreach (var marcaViewModel in _marcasCompleta)
                {
                    foreach (var propInfo in marcaViewModel.GetType().GetProperties())
                    {
                        if (propInfo.DeclaringType != null && propInfo.DeclaringType.Name == marcaViewModel.GetType().Name)
                        {
                            if (propInfo.CustomAttributes.Any(t => t.AttributeType.Name == "DisplayNameAttribute"))
                            {
                                sw.Write(propInfo.GetValue(marcaViewModel, null));
                            }
                        }
                        sw.Write("\t");
                    }
                    sw.Write(sw.NewLine);
                }
                sw.Close();

                Cursor.Current = Cursors.Default;
            }
            catch (System.IO.IOException e)
            {
                Cursor.Current = Cursors.Default;
                Console.WriteLine(@"Error al intentar escribir en el archivo {0}. Mensaje = {1}", sfd.FileName, e.Message);
            }
            catch (Exception e)
            {
                Cursor.Current = Cursors.Default;
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                var simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                simpleSound.Play();
                MessageBox.Show(@"Proceso finalizado exitosamente",
                    @"Excel",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign,
                    false);
            }
        }
        #endregion

        #region Imprimir
        private readonly RelayCommand _imprimirCommand;
        public ICommand ImprimirCommand => _imprimirCommand;

        public void Imprimir()
        {
            var marcasIList = new List<Marca>();
            var marcaLocal = new Marca();
            foreach (var m in _marcas)
            {
                marcaLocal.IdMarca = m.IdMarca;
                marcaLocal.Descripcion = m.Descripcion;
                marcaLocal.Estado = m.Estado;
                marcasIList.Add(marcaLocal);
            }
            _exposer.Expose<MarcaReportViewModel>(m => { m.Marcas = marcasIList; m.Initialize(); });
        }
        #endregion

        #region Inactivas
        private readonly RelayCommand _inactivasCommand;
        public ICommand InactivasCommand => _inactivasCommand;
        #endregion

        #region Literales
        private string _cantidadPaginasLiteral;

        public string CantidadPaginasLiteral
        {
            get
            {
                var cantidadPaginas = Paginas.Count();
                if (cantidadPaginas == 0)
                    _cantidadPaginasLiteral = "";
                else if (cantidadPaginas == 1)
                    _cantidadPaginasLiteral = " de 1";
                else
                    _cantidadPaginasLiteral = string.Format(" de {0}", cantidadPaginas);
                return _cantidadPaginasLiteral;
            }
        }

        private string _cantidadRegistrosLiteral;

        public string CantidadRegistrosLiteral
        {
            get
            {
                if (CantidadRegistros == 0)
                    _cantidadRegistrosLiteral = "";
                else if (CantidadRegistros == 1)
                    _cantidadRegistrosLiteral = string.Format("Una marca {0}", EsMarcaActiva ? "activa" : "inactiva");
                else
                    _cantidadRegistrosLiteral = string.Format("{0} marcas {1}", CantidadRegistros, EsMarcaActiva ? "activas" : "inactivas");
                return _cantidadRegistrosLiteral;
            }
        }
        #endregion

        #region Páginas

        public int PaginaNumero { get; set; }
        public int TamanoPagina { get; set; }

        public IEnumerable<Pagina> Paginas => paginas(CantidadRegistros % TamanoPagina == 0 ? CantidadRegistros / TamanoPagina : CantidadRegistros / TamanoPagina + 1);

        private Pagina[] paginas(int pCantidadPaginas)
        {
            Pagina[] v = new Pagina[pCantidadPaginas];
            for (int i = 0; i < pCantidadPaginas; i++)
            {
                v[i] = new Pagina { Id = i + 1, Descripcion = (i + 1).ToString() };
            }
            return v;
        }

        private int _selectedPagina;

        public int SelectedPagina
        {
            get { return _selectedPagina; }
            set
            {
                if (!Equals(_selectedPagina, value))
                {
                    _selectedPagina = value;
                    PaginaNumero = value;
                    OnPropertyChanged("SelectedPagina");
                    //ResetAnomalias();
                }
            }
        }
        #endregion

        #region RefrescarMarcas
        private int CantidadRegistros { get; set; }
        private BindingList<MarcaViewModel> _marcas = new BindingList<MarcaViewModel>();
        private BindingList<MarcaViewModel> _marcasCompleta = new BindingList<MarcaViewModel>();

        //TODO - Indicación de Fabio
        //Lo que hace eso es que la propiedad en el model solo se inicializa cuando se pide (es un detalle, no te preocupes)
        //public IEnumerable<MarcaViewModel> Marcas => marcas;
        public IEnumerable<MarcaViewModel> Marcas => _marcas ?? (_marcas = new BindingList<MarcaViewModel>
                                                     (_marcaRepository.GetMarcas(PaginaNumero, TamanoPagina, Buscar).Select(m => new MarcaViewModel(_marcaRepository)
                                                         { IdMarca = m.IdMarca, Descripcion = m.Descripcion, Estado = m.Estado }).ToList()));

        public void RefreshMarcas(Enums.EstadoRegistros estadoRegistros)
        {
            //TODO - ¿Está bien así?
            _marcas.Clear();
            _marcasCompleta.Clear();
            foreach (Marca m in estadoRegistros == Enums.EstadoRegistros.Habilitados ? _marcaRepository.GetMarcas(PaginaNumero, TamanoPagina, Buscar) : _marcaRepository.GetMarcasInactivas(PaginaNumero, TamanoPagina, Buscar))
            {
                _marcas.Add(new MarcaViewModel(_marcaRepository) { IdMarca = m.IdMarca, Descripcion = m.Descripcion, Estado = m.Estado });
            }
            foreach (Marca m in estadoRegistros == Enums.EstadoRegistros.Habilitados ? _marcaRepository.GetMarcas() : _marcaRepository.GetMarcasInactivas())
            {
                _marcasCompleta.Add(new MarcaViewModel(_marcaRepository) { IdMarca = m.IdMarca, Descripcion = m.Descripcion, Estado = m.Estado });
            }

            EsMarcaActiva = estadoRegistros == Enums.EstadoRegistros.Habilitados;
            CantidadRegistros = estadoRegistros == Enums.EstadoRegistros.Habilitados ? _marcaRepository.GetMarcasCantidad(Buscar) : _marcaRepository.GetMarcasInactivasCantidad(Buscar);
        }
        #endregion

        #region Persistir
        public void Persist()
        {
            var marca = new Marca { IdMarca = IdMarca, Descripcion = Descripcion };
            _marcaRepository.Persist(marca);
            RefreshMarcas(Enums.EstadoRegistros.Habilitados);
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            // Liberar eventuales recursos como procesos en backgroud, subscripciones a eventos de aplicación.. etc.
            base.Dispose(disposing);
        }
    }
}

