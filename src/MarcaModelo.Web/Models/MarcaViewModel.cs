using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarcaModelo.Web.Models
{
    public class MarcaViewModel
    {
        private int? idMarca;
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

        //[DisplayName("Descripción")]
        //[ReadOnly(false)]
        //[StringLength(100, MinimumLength = 2)]
        //[Required(ErrorMessage = "La Descripción es obligatoria")]
        public string Descripcion
        { get; set; }

        //[DisplayName("Estado")]
        //[ReadOnly(true)]
        //[Hidden(true)]
        public string Estado
        { get; set; }
    }
}