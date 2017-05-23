using MarcaModelo.Data;
using MarcaModelo.WinForm.Common;
using System;
using System.Linq;

namespace MarcaModelo.WinForm.Models
{
    public class MarcaViewModel : ViewModelBase
    {
        private readonly IMarcaRepository marcaRepository;
        private readonly Lazy<ModeloViewModel[]> modelos;

        public MarcaViewModel(IMarcaRepository marcaRepository)
        {
            //[CMS] - Lazyload ¿Está bien así?
            modelos = new Lazy<ModeloViewModel[]>(() =>
            marcaRepository.Modelos().ToArray()
            .Select(x => new ModeloViewModel { IDMarca = marcaRepository.IDMarca }).ToArray());
            this.marcaRepository = marcaRepository;
        }

        public int? IDMarca
        { get; set; }
        
        public string Descripcion
        { get; set; }
        
        public string Estado
        { get; set; }
    }
}
