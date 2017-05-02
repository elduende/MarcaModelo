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
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres, máximo 50")]
        [MaxLength(50, ErrorMessage = "Mínimo 5 caracteres, máximo 50")]
        public string Descripcion { get; set; }
        [DisplayName("Estado")]
        [ReadOnly(true)]
        [Hidden(true)]
        public string Estado { get; set; }

        IEnumerable<Marca> GetMarcas { get; set; }

        //[DisplayName("Estado")]
        //[ReadOnly(true)]
        //[Hidden(true)]
        //public string IDUsuarioCreacion { get; set; }
        //[DisplayName("Usuario de Creación")]
        //[ReadOnly(true)]
        //[Hidden(true)]
        //public int FechaCreacion { get; set; }
        //[DisplayName("Fecha de Creación")]
        //[ReadOnly(true)]
        //[Hidden(true)]
        //public string HoraCreacion { get; set; }
        //[DisplayName("Hora de Creación")]
        //[ReadOnly(true)]
        //[Hidden(true)]
        //public string IDUsuarioUltimaModificacion { get; set; }
        //[DisplayName("Usuario de Última Modificación")]
        //[ReadOnly(true)]
        //[Hidden(true)]
        //public int FechaUltimaModificacion { get; set; }
        //[DisplayName("Fecha de Última Modificación")]
        //[ReadOnly(true)]
        //[Hidden(true)]
        //public string HoraUltimaModificacion { get; set; }
        //[DisplayName("Hora de Última Modificación")]
        //[ReadOnly(true)]
        //[Hidden(true)]
        //public IList<Modelo> Modelos { get; set; }
    }
}
