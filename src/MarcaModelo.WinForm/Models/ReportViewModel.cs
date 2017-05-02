using MarcaModelo.WinForm.Common;
using Microsoft.Reporting.WinForms;

namespace MarcaModelo.WinForm.Models
{
    public abstract class ReportViewModel : ViewModelBase
    {
        public abstract string Titulo { get; }
        public abstract void SetReport(LocalReport report);
    }
}
