using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MarcaModelo.Data;
using MarcaModelo.WinForm.Common.Attributes;

namespace MarcaModelo.WinForm.Models
{
    class ModeloViewModel
    {
        public int IDModelo { get; set; }
        [DisplayName("ID Modelo")]
        [ReadOnly(true)]
        public int IDMarca { get; set; }
        public string Descripcion { get; set; }
        [DisplayName("Descripción")]
        [ReadOnly(true)]
        public string Estado { get; set; }
        [DisplayName("Estado")]
        [ReadOnly(true)]
        public string IDUsuarioCreacion { get; set; }
        [DisplayName("Usuario de Creación")]
        [ReadOnly(true)]
        public int FechaCreacion { get; set; }
        [DisplayName("Fecha de Creación")]
        [ReadOnly(true)]
        public string HoraCreacion { get; set; }
        [DisplayName("Hora de Creación")]
        [ReadOnly(true)]
        public string IDUsuarioUltimaModificacion { get; set; }
        [DisplayName("Usuario de Última Modificación")]
        [ReadOnly(true)]
        public int FechaUltimaModificacion { get; set; }
        [DisplayName("Fecha de Última Modificación")]
        [ReadOnly(true)]
        public string HoraUltimaModificacion { get; set; }
        [DisplayName("Hora de Última Modificación")]
        [ReadOnly(true)]
        private Marca marca { get; set; }
    }
}
