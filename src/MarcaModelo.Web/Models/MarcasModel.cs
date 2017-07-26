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
        private readonly IMarcaRepository _marcaRepository;
        private readonly Lazy<ModeloModel[]> _modelos;

        //TODO - Tuve que agregar este constructor sin parámetros porque sino el Create da error
        public MarcasModel()
        { }

        public MarcasModel(IMarcaRepository marcaRepository)
        {
            //TODO - Lazyload ¿Está bien así?
            _modelos = new Lazy<ModeloModel[]>(() =>
            marcaRepository.Modelos().ToArray()
            .Select(x => new ModeloModel { IdMarca = marcaRepository.IdMarca }).ToArray());
            _marcaRepository = marcaRepository;
        }

        [Display(Name = "IDMarca")]
        [HiddenInput(DisplayValue = false)]
        public int IdMarca { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "La Marca es requerida.")]
        public string Descripcion { get; set; }

        [Display(Name = "Estado")]
        [HiddenInput(DisplayValue = false)]
        public string Estado { get; set; }
    }
}