using System;
using System.Linq;
using MarcaModelo.Data;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MarcaModelo.Web.Common;

namespace MarcaModelo.Web.Models
{
    public class MarcasModel : ViewModelBase
    {
        private readonly IMarcaRepository marcaRepository;
        private readonly Lazy<ModeloModel[]> modelos;

        public MarcasModel(IMarcaRepository marcaRepository)
        {
            //[CMS] - Lazyload ¿Está bien así?
            modelos = new Lazy<ModeloModel[]>(() =>
            marcaRepository.Modelos().ToArray()
            .Select(x => new ModeloModel { IDMarca = marcaRepository.IDMarca }).ToArray());
            this.marcaRepository = marcaRepository;
        }

        [Display(Name = "IDMarca")]
        [HiddenInput(DisplayValue = false)]
        public int IDMarca { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "La Marca es requerida.")]
        public string Descripcion { get; set; }

        [Display(Name = "Estado")]
        [HiddenInput(DisplayValue = false)]
        public string Estado { get; set; }
    }
}