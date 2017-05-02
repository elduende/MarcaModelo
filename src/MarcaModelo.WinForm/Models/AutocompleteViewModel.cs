using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MarcaModelo.WinForm.Common;

namespace MarcaModelo.WinForm.Models
{
    public class AutocompleteViewModel : ViewModelBase
    {
        private int zonaIdSelecionada;
        private readonly List<ZonaModel> zonas;

        public AutocompleteViewModel()
        {
            zonas = new[] { new ZonaModel { Id = -1, Nombre = "No seleccionada" } }.Concat(CultureInfo.GetCultures(CultureTypes.AllCultures).OrderBy(x => x.DisplayName).Select(x => new ZonaModel
            {
                Id = x.LCID,
                Nombre = x.DisplayName
            })).ToList();
        }

        public int ZonaIdSelecionada
        {
            get { return zonaIdSelecionada; }
            set
            {
                if (SetProperty(ref zonaIdSelecionada, value, nameof(zonaIdSelecionada)))
                {
                    OnPropertyChanged(nameof(NombreZonaSeleccionada));
                };
            }
        }

        public IEnumerable<ZonaModel> Zonas => zonas;

        public string NombreZonaSeleccionada => zonas.FirstOrDefault(x => x.Id == ZonaIdSelecionada)?.Nombre ?? "";
    }

    public class ZonaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
