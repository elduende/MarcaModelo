using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MarcaModelo.Data;
using MarcaModelo.WinForm.Common;
using MarcaModelo.WinForm.Common.Attributes;
using System.Collections.Generic;

namespace MarcaModelo.WinForm.Models
{
    public class MarcaViewModel : ViewModelBase
    {
        private int idMarca;
        private string descripcion;
        private string estado;

        public MarcaViewModel()
        {

        }

        //[DisplayName("ID Marca")]
        //[ReadOnly(true)]
        //[Hidden(true)]
        public int? IDMarca
        { get; set; }
        //{
        //    get { return idMarca; }
        //    set { SetProperty(ref idMarca, value, nameof(IDMarca)); }
        //}

        //[DisplayName("Descripción")]
        //[ReadOnly(false)]
        //[StringLength(100, MinimumLength = 2)]
        //[Required(ErrorMessage = "La Descripción es obligatoria")]
        public string Descripcion
        { get; set; }
        //{
            //get { return descripcion; }
            //set
            //{
            //    if (!Equals(descripcion, value))
            //    {
            //        descripcion = value;
            //        OnPropertyChanged("Descripcion");
            //        //ResetAnomalias();
            //    }
            //}
        //}

        //[DisplayName("Estado")]
        //[ReadOnly(true)]
        //[Hidden(true)]
        public string Estado
        { get; set; }
        //{
        //    get { return estado; }
        //    set { SetProperty(ref estado, value, nameof(Estado)); }
        //}

        //public IList<Modelo> Modelos { get; }
        //public void Add(Modelo modelo)
        //{
        //    throw new NotImplementedException();
        //}
        //public MarcaViewModel GetById(int IDMarca)
        //{
        //    throw new NotImplementedException();
        //}
        //public IEnumerable<Marca> GetMarcas()
        //{
        //    throw new NotImplementedException();
        //}
        //public void Persist(Marca marca)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
