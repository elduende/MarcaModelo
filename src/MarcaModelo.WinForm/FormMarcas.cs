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

            btnConfirmar.Bind(model.AgregarCommand);
            
            btnImprimir.Bind(model.ImprimirCommand);
            btnCerrar.Bind(model.CloseCommand);
            btnConfirmar
                .BindErrors(model, errorProvider)
                .Bind(model.ConfirmarCommand);

            txtDescripcion.BindValue(model, m => m.Descripcion);

            dGV.AutoGenerateColumns = false;
            IDMarcaColumn.Bind<MarcaViewModel>(m => m.IDMarca);
            DescripcionColumn.Bind<MarcaViewModel>(m => m.Descripcion);
            EstadoColumn.Bind<MarcaViewModel>(m => m.Estado);
            dGV.BindSource(model, m => m.Marcas);

            errorProvider.DataSource = model; // <=== es importante que esté luego de bindear los otros controles de las propiedades
        }
    }
}
