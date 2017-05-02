using MarcaModelo.Services;

namespace MarcaModelo.WinForm
{
    public static class ReportsConfig
    {
        public static void RegisterAllReports(IReportsStore store)
        {
            store.RegisterFrom("MarcaModelo.Reports.dll");
        }
    }
}
