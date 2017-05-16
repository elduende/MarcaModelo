using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MarcaModelo.Web.Common;

namespace MarcaModelo.Web.Models
{
    public class MarcasModel : ViewModelBase
    {
        [Display(Name = "IDMarca")]
        [HiddenInput(DisplayValue = false)]
        public int? IDMarca { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "La Marca es requerida.")]
        public string Descripcion { get; set; }

        [Display(Name = "Estado")]
        [HiddenInput(DisplayValue = false)]
        public string Estado { get; set; }
    }
}