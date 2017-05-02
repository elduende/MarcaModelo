using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using MarcaModelo.Services;
using MarcaModelo.WinForm.Common;
using MarcaModelo.WinForm.Models;

namespace MarcaModelo.WinForm
{
    static class Program
    {
        private static readonly SimpleServiceContainer container = new SimpleServiceContainer();

        [STAThread]
        internal static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitializeDefaultFormIcon();

            AuthenticationStart.Initialize();
            container.RegisterAllServices();
            DomainEventsWiring.RegisterHandlers(container);
            ReportsConfig.RegisterAllReports(container.GetInstance<IReportsStore>());
            container.RegisterApplicationViewModels(container);

            var mainExposer = container.GetInstance<IViewModelExposer>();
            var mainForm = new FormMain(new MainViewModel(mainExposer));
            Application.Run(mainForm);
            Application.ThreadExit += (sender, args) =>
            {
                mainExposer.Dispose();
                container.Dispose();
            };
        }

        private static void InitializeDefaultFormIcon()
        {
            try
            {
                Icon appIcon;
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MarcaModelo.WinForm.favicon.ico"))
                {
                    appIcon = new Icon(stream);
                }
                typeof(Form).GetField("defaultIcon", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, appIcon);
            }
            catch (Exception)
            {
            }
        }
    }
}
