using System.Windows.Forms;
using MarcaModelo.WinForm.Common;
using MarcaModelo.WinForm.Models;

namespace MarcaModelo.WinForm
{
    public sealed partial class FormMain : Form
    {
        public MainViewModel Model { get; set; }

        public FormMain(MainViewModel model)
        {
            InitializeComponent();

            Text = @"HDF.Net";
            this.Bind(model);
            Model = model;

            marcasToolStripMenuItem.Bind(model.Marcas);
            cerrarToolStripMenuItem.Click += (sender, args) => model.Close();

            errorProvider.DataSource = model; // <=== es importante que esté luego de bindear los otros controles de las propiedades
        }
    }
}
