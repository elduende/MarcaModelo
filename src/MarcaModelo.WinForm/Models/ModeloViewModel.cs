using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MarcaModelo.Data;
using MarcaModelo.WinForm.Common.Attributes;

namespace MarcaModelo.WinForm.Models
{
    class ModeloViewModel
    {
        [DisplayName("ID Modelo")]
        [ReadOnly(true)]
        [Hidden(true)]
        public int IDModelo { get; set; }

        [DisplayName("ID Marca")]
        [ReadOnly(true)]
        [Hidden(true)]
        public int IDMarca { get; set; }

        [DisplayName("Descripción")]
        [ReadOnly(true)]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres, máximo 50")]
        [MaxLength(50, ErrorMessage = "Mínimo 2 caracteres, máximo 50")]
        [Required]
        public string Descripcion { get; set; }

        [DisplayName("Estado")]
        [ReadOnly(true)]
        [Hidden(true)]
        public string Estado { get; set; }

        [DisplayName("Marca")]
        [ReadOnly(true)]
        [Hidden(true)]
        private Marca marca { get; set; }
    }
}
