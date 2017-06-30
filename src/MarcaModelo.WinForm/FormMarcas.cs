using System;
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
            
            #region Inicio
            Text = @"Marcas";
            this.Bind(model);
            Model = model;
            #endregion

            #region LeerXml
            var pPagina = 0;
            var pTamanoPagina = 0;
            var pBuscar = "";
            var pEstadoRegistrosGrilla = Enums.EstadoRegistros.Habilitados;
            FormConfigurationXmlHelper.LeerXml(this, ref pPagina, ref pTamanoPagina, ref pEstadoRegistrosGrilla, ref pBuscar, dGV);
            #endregion

            #region Grilla
            dGV.AutoGenerateColumns = false;
            IDMarcaColumn.Bind<MarcasViewModel>(m => m.IdMarca);
            DescripcionColumn.Bind<MarcasViewModel>(m => m.Descripcion);
            EstadoColumn.Bind<MarcasViewModel>(m => m.Estado);

            model.TamanoPagina = pTamanoPagina;

            model.RefreshMarcas(pEstadoRegistrosGrilla);

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
            nudTamanoPagina.ValueChanged += (sender, args) => model.RefreshMarcas(model.EsMarcaActiva ? Enums.EstadoRegistros.Habilitados : Enums.EstadoRegistros.Inhabilitados);

            cboPagina.BindSource(model, m => m.Paginas, p => p.Id, p => p.Descripcion);
            cboPagina.SelectedIndexChanged += (sender, args) => model.RefreshMarcas(model.EsMarcaActiva ? Enums.EstadoRegistros.Habilitados : Enums.EstadoRegistros.Inhabilitados);
            cboPagina.BindValue(model, m => m.SelectedPagina);
            model.SelectedPagina = pPagina;

            btnProximo.Click += (sender, args) => cboPagina.SelectedIndex += cboPagina.SelectedIndex < cboPagina.Items.Count - 1 ? 1 : 0;
            btnAnterior.Click += (sender, args) => cboPagina.SelectedIndex -= cboPagina.SelectedIndex > 0 ? 1 : 0;
            btnPrimero.Click += (sender, args) => cboPagina.SelectedIndex = 0;
            btnUltimo.Click += (sender, args) => cboPagina.SelectedIndex = cboPagina.Items.Count - 1;

            lblCantidadRegistros.BindValue(model, m => m.CantidadRegistrosLiteral);

            lblPaginas.BindValue(model, m => m.CantidadPaginasLiteral);
            #endregion Grilla

            #region Imprimir
            btnImprimir.Bind(model.ImprimirCommand);
            imprimirToolStripMenuItem.Bind(model.ImprimirCommand);
            #endregion

            #region Excel
            btnExcel.Bind(model.ExcelCommand);
            excelToolStripMenuItem.Bind(model.ExcelCommand);
            #endregion

            #region Cerrar
            btnCerrar.Click += (sender, args) => model.Close();
            cerrarToolStripMenuItem.Click += (sender, args) => model.Close();
            #endregion

            #region Confirmar
            btnConfirmar
                .BindErrors(model, errorProvider)
                .Bind(model.ConfirmarCommand);
            #endregion

            #region Desactivar
            btnDesactivar.Bind(model.DesactivarCommand);
            desactivarToolStripMenuItem.Bind(model.DesactivarCommand);
            #endregion

            #region Activar
            btnActivar.Bind(model.ActivarCommand);
            activarToolStripMenuItem.Bind(model.ActivarCommand);
            #endregion

            #region Activas
            btnActivas.Bind(model.ActivasCommand);
            activasToolStripMenuItem.Bind(model.ActivasCommand);
            btnActivas.Click += (sender, args) => cboPagina.BindSource(model, m => m.Paginas, p => p.Id, p => p.Descripcion);
            activasToolStripMenuItem.Click += (sender, args) => cboPagina.BindSource(model, m => m.Paginas, p => p.Id, p => p.Descripcion);
            #endregion

            #region Inactivas
            btnInactivas.Bind(model.InactivasCommand);
            inactivasToolStripMenuItem.Bind(model.InactivasCommand);
            btnInactivas.Click += (sender, args) => cboPagina.BindSource(model, m => m.Paginas, p => p.Id, p => p.Descripcion);
            inactivasToolStripMenuItem.Click += (sender, args) => cboPagina.BindSource(model, m => m.Paginas, p => p.Id, p => p.Descripcion);
            #endregion

            #region Agregar
            btnAgregar.Bind(model.AgregarCommand);
            agregarToolStripMenuItem.Bind(model.AgregarCommand);
            btnAgregar.Click += (sender, args) => { txtDescripcion.Focus(); };
            agregarToolStripMenuItem.Click += (sender, args) => { txtDescripcion.Focus(); };
            #endregion

            #region Descripcion
            txtDescripcion.BindValue(model, m => m.Descripcion);
            #endregion

            #region Buscar
            model.Buscar = pBuscar;
            txtBuscar.BindValue(model, m => m.Buscar);
            txtBuscar.KeyUp += (sender, args) => cboPagina.BindSource(model, m => m.Paginas, p => p.Id, p => p.Descripcion);
            #endregion
            
            SetToolTips();

            errorProvider.DataSource = model; // <=== es importante que esté luego de bindear los otros controles de las propiedades
        }

        protected override void OnClosed(EventArgs e)
        {
            FormConfigurationXmlHelper.GuardarXml(this, Convert.ToInt32(cboPagina.SelectedIndex == -1 ? "0" : cboPagina.SelectedIndex.ToString()), pTamanoPagina: Convert.ToInt32(nudTamanoPagina.Value), pRegistrosGrilla: Model.EsMarcaActiva ? Enums.EstadoRegistros.Habilitados : Enums.EstadoRegistros.Inhabilitados, pBuscar: txtBuscar.Text, pDataGrid: dGV);
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
            toolTip.SetToolTip(btnPrimero, "Primer registro");
            toolTip.SetToolTip(btnAnterior, "Registro anterior");
            toolTip.SetToolTip(btnProximo, "Próximo registro");
            toolTip.SetToolTip(btnUltimo, "Último registro");
            toolTip.SetToolTip(cboPagina, "Página número");
        }
    }
}
