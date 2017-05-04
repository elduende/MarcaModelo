﻿using System.Windows.Forms;
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

            txtDescripcion.BindValue(model, m => m.Descripcion);

            dGV.AutoGenerateColumns = false;
            IDMarcaColumn.Bind<MarcaViewModel>(m => m.IDMarca);
            DescripcionColumn.Bind<MarcaViewModel>(m => m.Descripcion);
            EstadoColumn.Bind<MarcaViewModel>(m => m.Estado);
            dGV.BindSource(model, m => m.Marcas);
        }
    }
}
