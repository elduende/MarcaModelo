using System.Windows.Forms;
using MarcaModelo.WinForm.Common;
using MarcaModelo.WinForm.Models;

namespace MarcaModelo.WinForm
{
    public partial class FormMain : Form
    {
        public FormMain(MainViewModel model)
        {
            InitializeComponent();
            btnMarcas.Bind(model.Marcas);
        }
    }
}
