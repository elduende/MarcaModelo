using MarcaModelo.Data;
using MarcaModelo.WinForm.Common;
using System;
using System.Linq;

namespace MarcaModelo.WinForm.Models
{
    public class MarcaViewModel : ViewModelBase
    {
        private readonly IMarcaRepository _marcaRepository;
        private readonly Lazy<ModeloViewModel[]> _modelos;

        public MarcaViewModel(IMarcaRepository marcaRepository)
        {
            //[CMS] - Lazyload ¿Está bien así?
            _modelos = new Lazy<ModeloViewModel[]>(() =>
            marcaRepository.Modelos().ToArray()
            .Select(x => new ModeloViewModel { IdMarca = marcaRepository.IdMarca }).ToArray());
            _marcaRepository = marcaRepository;
        }

        public int IdMarca
        { get; set; }
        
        public string Descripcion
        { get; set; }
        
        public string Estado
        { get; set; }
    }
}
