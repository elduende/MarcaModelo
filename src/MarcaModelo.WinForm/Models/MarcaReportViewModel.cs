using System.Collections.Generic;
using MarcaModelo.Data;
using MarcaModelo.Services;
using Microsoft.Reporting.WinForms;

namespace MarcaModelo.WinForm.Models
{
    public class MarcaReportViewModel : ReportViewModel
    {
        private readonly IReportsProvider _reportsProvider;

        public MarcaReportViewModel(IReportsProvider reportsProvider)
        {
            _reportsProvider = reportsProvider;
        }

        public IEnumerable<Marca> Marcas { get; set; }
        public Marca Marca { get; set; }
        public override string Titulo => "Marcas";

        public void Initialize()
        {
            Marcas = GetMarcas();
        }

        public override void SetReport(LocalReport report)
        {
            report.LoadReportDefinition(_reportsProvider.GetResourceByReportName("Marcas.rdlc"));
            report.DataSources.Add(new ReportDataSource("Marcas", Marcas));
        }

        private IEnumerable<Marca> GetMarcas()
        {
            IsBusy = true;
            try
            {
               for (int i = 0; i < 1000; i++)
                {
                    yield return new Marca { IdMarca = i, Descripcion = i.ToString(), Estado = "A" };
                    //.Set(new[] { new DocumentoDeRemito { DocumentoId = 1 }, new DocumentoDeRemito { DocumentoId = 2 } });
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
