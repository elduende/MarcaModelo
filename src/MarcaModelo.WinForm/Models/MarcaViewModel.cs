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
        [DisplayName("IDMarca")]
        [ReadOnly(true)]
        [Hidden(true)]
        public int IDMarca { get; set; }
        [DisplayName("Descripción")]
        [ReadOnly(false)]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres, máximo 50")]
        [MaxLength(50, ErrorMessage = "Mínimo 2 caracteres, máximo 50")]
        public string Descripcion { get; set; }
        [DisplayName("Estado")]
        [ReadOnly(true)]
        [Hidden(true)]
        public string Estado { get; set; }
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
    }
}
