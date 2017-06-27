using System;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;
using MarcaModelo.WinForm.Common;
using MarcaModelo.WinForm.Models;

namespace MarcaModelo.WinForm
{
    public sealed partial class FormMarcas : Form
    {
        public MarcasViewModel Model { get; set; }

        public FormMarcas(MarcasViewModel model)
        {
            InitializeComponent();
            Text = @"Marcas";
            this.Bind(model);
            Model = model;

            dGV.AutoGenerateColumns = false;
            IDMarcaColumn.Bind<MarcasViewModel>(m => m.IdMarca);
            DescripcionColumn.Bind<MarcasViewModel>(m => m.Descripcion);
            EstadoColumn.Bind<MarcasViewModel>(m => m.Estado);

            var pPagina = 0;
            var pTamanoPagina = 0;
            var estadoRegistrosGrilla = Enums.EstadoRegistros.Habilitados;
            FormConfigurationXmlHelper.LeerXml(this, ref pPagina, ref pTamanoPagina, ref estadoRegistrosGrilla, dGV);
            model.TamanoPagina = pTamanoPagina;

            model.RefreshMarcas(estadoRegistrosGrilla);

            dGV.BindSource(model, m => m.Marcas);

            //TODO ¿Se hace así esto?
            dGV.Click += (sender, args) =>
            {
                if (dGV.CurrentRow == null) return;
                model.IdMarca = (int)dGV.CurrentRow.Cells[0].Value;
                model.Descripcion = dGV.CurrentRow.Cells[1].Value.ToString();
                model.Estado = dGV.CurrentRow.Cells[2].Value.ToString();
            };

            dGV.DataBindingComplete += (sender, args) =>
            {
                if (dGV.CurrentRow != null)
                {
                    model.IdMarca = (int)dGV.CurrentRow.Cells[0].Value;
                    model.Descripcion = dGV.CurrentRow.Cells[1].Value.ToString();
                    model.Estado = dGV.CurrentRow.Cells[2].Value.ToString();
                }
            };

            nudTamanoPagina.BindValue(model, m => m.TamanoPagina);
            nudTamanoPagina.TextChanged += (sender, args) => cboPagina.BindSource(model, m => m.Paginas, p => p.Id, p => p.Descripcion);
            nudTamanoPagina.ValueChanged += (sender, args) => model.RefreshMarcas(model.MuestraMarcasActivas ? Enums.EstadoRegistros.Habilitados : Enums.EstadoRegistros.Inhabilitados);

            cboPagina.BindSource(model, m => m.Paginas, p => p.Id, p => p.Descripcion);
            cboPagina.SelectedIndexChanged += (sender, args) => model.RefreshMarcas(model.MuestraMarcasActivas ? Enums.EstadoRegistros.Habilitados : Enums.EstadoRegistros.Inhabilitados);
            cboPagina.BindValue(model, m => m.SelectedPagina);
            
            lblCantidadRegistros.BindValue(model, m => m.CantidadRegistrosLiteral);

            btnImprimir.Bind(model.ImprimirCommand);
            btnCerrar.Click += (sender, args) => model.Close();
            btnConfirmar
                .BindErrors(model, errorProvider)
                .Bind(model.ConfirmarCommand);

            btnDesactivar.Bind(model.DesactivarCommand);
            btnActivar.Bind(model.ActivarCommand);
            btnActivas.Bind(model.ActivasCommand);
            btnInactivas.Bind(model.InactivasCommand);
            btnAgregar.Bind(model.AgregarCommand);

            btnAgregar.Click += (sender, args) =>
            {
                txtDescripcion.Focus();
            };

            txtDescripcion.BindValue(model, m => m.Descripcion);

            SetToolTips();

            errorProvider.DataSource = model; // <=== es importante que esté luego de bindear los otros controles de las propiedades
        }

        protected override void OnClosed(EventArgs e)
        {
            //FormConfigurationXmlHelper.GuardarXml(this, Convert.ToInt32(cboPagina.SelectedValue == null || cboPagina.SelectedIndex == 0 ? "0" : cboPagina.SelectedIndex.ToString()), pTamanoPagina: 25, pRegistrosGrilla: Model.MuestraMarcasActivas? Enums.EstadoRegistros.Habilitados : Enums.EstadoRegistros.Inhabilitados, pDataGrid: dGV);
            FormConfigurationXmlHelper.GuardarXml(this, Convert.ToInt32(cboPagina.SelectedIndex == -1 ? "0" : cboPagina.SelectedIndex.ToString()), pTamanoPagina: Convert.ToInt32(nudTamanoPagina.Value), pRegistrosGrilla: Model.MuestraMarcasActivas ? Enums.EstadoRegistros.Habilitados : Enums.EstadoRegistros.Inhabilitados, pDataGrid: dGV);
        }

        private void SetToolTips()
        {
            var toolTip = new ToolTip();
            toolTip.SetToolTip(btnActivas, "Activas");
            toolTip.SetToolTip(btnInactivas, "Inactivas");
            toolTip.SetToolTip(btnConfirmar, "Confirmar");
            toolTip.SetToolTip(btnAgregar, "Agregar");
            toolTip.SetToolTip(btnActivar, "Activar");
            toolTip.SetToolTip(btnDesactivar, "Desactivar");
            toolTip.SetToolTip(btnExcel, "Excel");
            toolTip.SetToolTip(btnImprimir, "Imprimir");
            toolTip.SetToolTip(btnCerrar, "Cerrar");
            toolTip.SetToolTip(nudTamanoPagina, "Cantidad de registros por página");
        }
    }
}
