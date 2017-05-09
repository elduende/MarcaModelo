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

            btnImprimir.Bind(model.ImprimirCommand);
            btnCerrar.Bind(model.CloseCommand);
            btnConfirmar
                .BindErrors(model, errorProvider)
                .Bind(model.ConfirmarCommand);
            //[CMS] ¿Cómo se bindea un bindingNavigator?
            //bindingNavigatorDeleteItem.
            
            btnEliminar.Bind(model.DesactivarCommand);
            txtDescripcion.BindValue(model, m => m.Descripcion);

            dGV.AutoGenerateColumns = false;
            IDMarcaColumn.Bind<MarcasViewModel>(m => m.IDMarca);
            DescripcionColumn.Bind<MarcasViewModel>(m => m.Descripcion);
            EstadoColumn.Bind<MarcasViewModel>(m => m.Estado);
            dGV.BindSource(model, m => m.Marcas);
            //[CMS] ¿Se hace así esto?
            dGV.Click += (sender, args) => { model.IDMarca = (int?)dGV.CurrentRow.Cells[0].Value; };
            errorProvider.DataSource = model; // <=== es importante que esté luego de bindear los otros controles de las propiedades
        }
    }
}
