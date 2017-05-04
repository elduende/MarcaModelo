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
        private Marca marca { get; set; }
    }
}
