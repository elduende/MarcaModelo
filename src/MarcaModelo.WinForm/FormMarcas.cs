using System;
using System.Windows.Forms;
using MarcaModelo.WinForm.Common;
using MarcaModelo.WinForm.Models;

namespace MarcaModelo.WinForm
{
    public partial class FormMarcas : Form
    {
        public MarcasViewModel Model { get; set; }

        public FormMarcas(MarcasViewModel model)
        {
            InitializeComponent();
            this.Bind(model);
            Model = model;

            btnImprimir.Bind(model.ImprimirCommand);
            btnCerrar.Bind(model.CloseCommand);
            tSBSalir.Click += (sender, args) => model.Close();
            btnConfirmar
                .BindErrors(model, errorProvider)
                .Bind(model.ConfirmarCommand);

            btnDesactivar.Bind(model.DesactivarCommand);
            btnActivar.Bind(model.ActivarCommand);
            btnActivas.Bind(model.ActivasCommand);
            //tSBActivas.Click += (sender, args) => model.ActivasCommand();
            btnInactivas.Bind(model.InactivasCommand);
            //tSBInactivas.Click += (sender, args) => model.InactivasCommand();
            txtDescripcion.BindValue(model, m => m.Descripcion);

            dGV.AutoGenerateColumns = false;
            IDMarcaColumn.Bind<MarcasViewModel>(m => m.IdMarca);
            DescripcionColumn.Bind<MarcasViewModel>(m => m.Descripcion);
            EstadoColumn.Bind<MarcasViewModel>(m => m.Estado);
            
            var pPagina = 0;
            var pTamanoPagina = 0;
            var estadoRegistrosGrilla = Enums.EstadoRegistros.Habilitados;
            FormConfigurationXmlHelper.LeerXml(this, ref pPagina, ref pTamanoPagina, ref estadoRegistrosGrilla, dGV);
            model.Refresh(estadoRegistrosGrilla == Enums.EstadoRegistros.Habilitados);
            
            dGV.BindSource(model, m => m.Marcas);
            
            //[CMS] ¿Se hace así esto?
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

            btnAgregar.Click += (sender, args) =>
            {
                model.Descripcion = null;
                model.Estado = Enums.EstadoRegistrosDb.Habilitados.ToString();
                txtDescripcion.Focus();
            };

            errorProvider.DataSource = model; // <=== es importante que esté luego de bindear los otros controles de las propiedades
        }

        protected override void OnClosed(EventArgs e)
        {
            FormConfigurationXmlHelper.GuardarXml(this, 0, 0, Model.MuestraMarcasActivas? Enums.EstadoRegistros.Habilitados : Enums.EstadoRegistros.Inhabilitados, dGV);
        }
    }
}
