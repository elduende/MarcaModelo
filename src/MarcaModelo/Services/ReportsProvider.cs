using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MarcaModelo.Services
{
    public class ReportsProvider : IReportsProvider, IReportsStore
    {
        private class ReportResource
        {
            public ReportResource(Assembly assembly, string path)
            {
                Assembly = assembly;
                Path = path;
                var pathParts = path.Split('.');
                if (pathParts.Length <= 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(path), "Path del reporte no suportada. Se espera una path de un embeded resource (separada por '.').");
                }
                Name = string.Join(".", pathParts[pathParts.Length - 2], pathParts[pathParts.Length - 1]);
            }
            public string Path { get; }
            public Assembly Assembly { get; }
            public string Name { get; }
        }
        private readonly ConcurrentDictionary<string, ReportResource> pathIndex = new ConcurrentDictionary<string, ReportResource>();
        private readonly ConcurrentDictionary<string, ReportResource> nameIndex = new ConcurrentDictionary<string, ReportResource>();

        public IEnumerable<string> ReportsPaths()
        {
            return pathIndex.Keys;
        }

        public string ReportPathByReportName(string reportName)
        {
            if (reportName == null)
            {
                return null;
            }
            ReportResource resource;
            if (nameIndex.TryGetValue(reportName, out resource))
            {
                return resource.Path;
            }
            return null;
        }

        public Stream GetResourceByReportName(string reportName)
        {
            if (reportName == null)
            {
                throw new ArgumentNullException(nameof(reportName));
            }
            ReportResource resource;
            if (nameIndex.TryGetValue(reportName, out resource))
            {
                return resource.Assembly.GetManifestResourceStream(resource.Path);
            }
            return null;
        }

        public Stream GetResourcePath(string reportPath)
        {
            if (reportPath == null)
            {
                throw new ArgumentNullException(nameof(reportPath));
            }
            ReportResource resource;
            if (pathIndex.TryGetValue(reportPath, out resource))
            {
                return resource.Assembly.GetManifestResourceStream(resource.Path);
            }
            return null;
        }

        public IReportsStore Register(Assembly assembly, string reportResourcePath)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }
            if (string.IsNullOrWhiteSpace(reportResourcePath))
            {
                return this;
            }
            var reportResource = new ReportResource(assembly, reportResourcePath);
            pathIndex[reportResource.Path] = reportResource;
            nameIndex[reportResource.Name] = reportResource;
            return this;
        }

        public IReportsStore Register(Assembly assembly, IEnumerable<string> reportResourcePaths)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }
            foreach (var reportResourcePath in reportResourcePaths)
            {
                Register(assembly, reportResourcePath);
            }
            return this;
        }

        public IReportsStore RegisterFrom(Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }
            var resources = assembly.GetManifestResourceNames();
            var reports = resources.Where(x => x.EndsWith(".rdlc"));
            Register(assembly, reports);
            return this;
        }

        public IReportsStore RegisterFrom(string dllFullPath)
        {
            if (string.IsNullOrWhiteSpace(dllFullPath))
            {
                throw new ArgumentNullException(nameof(dllFullPath));
            }
            var assembly = Assembly.LoadFrom(dllFullPath);
            RegisterFrom(assembly);
            return this;
        }
    }
}