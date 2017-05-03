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

            btnAgregar.Bind(model.AgregarCommand);
            btnModificar.Bind(model.ModificarCommand);
            btnImprimir.Bind(model.ImprimirCommand);
            btnCerrar.Bind(model.CloseCommand);

            dGV.BindSource(model, m => m.Marcas);
        }
    }
}
