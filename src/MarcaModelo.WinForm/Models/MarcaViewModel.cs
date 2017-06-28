using MarcaModelo.Data;
using MarcaModelo.WinForm.Common;
using System;
using System.ComponentModel;
using System.Linq;
using MarcaModelo.WinForm.Common.Attributes;

namespace MarcaModelo.WinForm.Models
{
    public class MarcaViewModel : ViewModelBase
    {
        private readonly IMarcaRepository _marcaRepository;
        private readonly Lazy<ModeloViewModel[]> _modelos;

        public MarcaViewModel(IMarcaRepository marcaRepository)
        {
            //TODO - Lazyload ¿Está bien así?
            _modelos = new Lazy<ModeloViewModel[]>(() =>
            marcaRepository.Modelos().ToArray()
            .Select(x => new ModeloViewModel { IdMarca = marcaRepository.IdMarca }).ToArray());
            _marcaRepository = marcaRepository;
        }

        [Hidden]
        public int IdMarca
        { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion
        { get; set; }

        [Hidden]
        public string Estado
        { get; set; }
    }
}
