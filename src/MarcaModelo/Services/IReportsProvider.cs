using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace MarcaModelo.Services
{
    public interface IReportsProvider
    {
        IEnumerable<string> ReportsPaths();
        string ReportPathByReportName(string reportName);
        Stream GetResourceByReportName(string reportName);
        Stream GetResourcePath(string reportPath);
    }

    public interface IReportsStore
    {
        IReportsStore Register(Assembly assembly, string reportResourcePath);
        IReportsStore Register(Assembly assembly, IEnumerable<string> reportResourcePaths);
        IReportsStore RegisterFrom(Assembly assembly);
        IReportsStore RegisterFrom(string dllFullPath);
    }
}
