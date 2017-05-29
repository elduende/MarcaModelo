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
        private static readonly SimpleServiceContainer Container = new SimpleServiceContainer();

        [STAThread]
        internal static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitializeDefaultFormIcon();

            AuthenticationStart.Initialize();
            Container.RegisterAllServices();
            DomainEventsWiring.RegisterHandlers(Container);
            ReportsConfig.RegisterAllReports(Container.GetInstance<IReportsStore>());
            Container.RegisterApplicationViewModels(Container);

            var mainExposer = Container.GetInstance<IViewModelExposer>();
            var mainForm = new FormMain(new MainViewModel(mainExposer));
            Application.Run(mainForm);
            Application.ThreadExit += (sender, args) =>
            {
                mainExposer.Dispose();
                Container.Dispose();
            };
        }

        private static void InitializeDefaultFormIcon()
        {
            try
            {
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MarcaModelo.WinForm.favicon.ico"))
                {
                    if (stream != null)
                    {
                        var appIcon = new Icon(stream);
                        var memberInfo = typeof(Form).GetField("defaultIcon", BindingFlags.NonPublic | BindingFlags.Static);
                        if (memberInfo != null)
                            memberInfo
                                .SetValue(null, appIcon);
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
