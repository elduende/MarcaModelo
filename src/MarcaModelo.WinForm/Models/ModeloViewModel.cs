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
        [Hidden]
        public int IdModelo { get; set; }

        [DisplayName("ID Marca")]
        [ReadOnly(true)]
        [Hidden]
        public int IdMarca { get; set; }

        [DisplayName("Descripción")]
        [ReadOnly(true)]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres, máximo 50")]
        [MaxLength(50, ErrorMessage = "Mínimo 2 caracteres, máximo 50")]
        [Required]
        public string Descripcion { get; set; }

        [DisplayName("Estado")]
        [ReadOnly(true)]
        [Hidden]
        public string Estado { get; set; }

        [DisplayName("Marca")]
        [ReadOnly(true)]
        [Hidden]
        private Marca Marca { get; set; }
    }
}
