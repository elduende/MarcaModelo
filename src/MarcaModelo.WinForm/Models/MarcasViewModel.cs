using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Transactions;
using MarcaModelo.Data;
using MarcaModelo.Events;
using MarcaModelo.Services;
using MarcaModelo.Sistema.Events;
using MarcaModelo.WinForm.Common;

namespace MarcaModelo.WinForm.Models
{
    public class MarcasViewModel : ViewModelBase
    {
        private bool cierreControlado;
        
        public string descripcion;

        private readonly IViewModelExposer exposer;
        private readonly IMarcaRepository marcaRepository;
        private readonly BindingList<MarcaViewModel> marcas = new BindingList<MarcaViewModel>();
        private readonly RelayCommand imprimirCommand;
        private readonly RelayCommand agregarCommand;
        private readonly RelayCommand modificarCommand;

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
            modificarCommand = new RelayCommand(Modificar);
            CloseCommand = new RelayCommand(() =>
            {
                cierreControlado = true;
                Close();
            });
        }

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
            }
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

        public ICommand ModificarCommand
        {
            get { return modificarCommand; }
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
    }
}
