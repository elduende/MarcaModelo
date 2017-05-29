using System;
using System.Windows.Forms;
using MarcaModelo.WinForm.Common;
using MarcaModelo.WinForm.Models;
using Microsoft.Reporting.WinForms;

namespace MarcaModelo.WinForm
{
    public partial class FormPreviewReport : Form
    {
        public FormPreviewReport(ReportViewModel model)
        {
            InitializeComponent();
            this.Bind(model);
            Text = model.Titulo;
            reportViewer.ProcessingMode = ProcessingMode.Local;
            model.SetReport(reportViewer.LocalReport);
        }

        private void FormPreviewReport_Load(object sender, EventArgs e)
        {

            reportViewer.RefreshReport();
        }
    }
}
