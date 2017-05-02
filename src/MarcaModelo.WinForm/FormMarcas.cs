using System.Windows.Forms;
using MarcaModelo.WinForm.Common;
using MarcaModelo.WinForm.Models;

namespace MarcaModelo.WinForm
{
    public partial class FormMarcas : Form
    {
        public FormMarcas(MarcasViewModel model)
        {
            InitializeComponent();
            this.Bind(model);
            btnCerrar.Bind(model.CloseCommand);
            btnImprimir.Bind(model.ImprimirCommand);
            dGV.BindSource(model, m => m.Marcas);
        }
    }
}
