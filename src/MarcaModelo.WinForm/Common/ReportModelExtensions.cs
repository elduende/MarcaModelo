using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Microsoft.Reporting.WinForms;

namespace MarcaModelo.WinForm.Common
{
    public static class ReportModelExtensions
    {
        public static IEnumerable<ReportParameter> ToReportParameters(this object model)
        {
            if (ReferenceEquals(model, null))
            {
                yield break;
            }
            var properties = TypeDescriptor.GetProperties(model).Cast<PropertyDescriptor>();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyType = property.PropertyType;
                if (propertyType == typeof(string))
                {
                    yield return new ReportParameter(propertyName, (string)property.GetValue(model));
                }
                else if (propertyType.GetInterfaces().Contains(typeof(IEnumerable)))
                {
                    var enumerable = (IEnumerable)property.GetValue(model);
                    if (ReferenceEquals(enumerable, null))
                    {
                        yield return new ReportParameter(propertyName);
                    }
                    else
                    {
                        var firstValueToGetCollectionType = enumerable.Cast<object>().FirstOrDefault(x => !ReferenceEquals(null, x));
                        if (firstValueToGetCollectionType == null)
                        {
                            yield return new ReportParameter(propertyName);
                        }
                        else
                        {
                            // NOTE: Asume que no viene una collection mixta de objetos
                            var collectionElementType = firstValueToGetCollectionType.GetType();
                            var values = (from object item in enumerable select PropertyValueToString(item, collectionElementType)).ToArray();
                            yield return new ReportParameter(propertyName, values);
                        }
                    }
                }
                else
                {
                    yield return new ReportParameter(propertyName, PropertyValueToString(property.GetValue(model), propertyType));
                }
            }
        }

        private static string PropertyValueToString(object value, Type propertyType)
        {
            if (ReferenceEquals(value, null))
            {
                return null;
            }
            if (propertyType == typeof(DateTime))
            {
                return ((DateTime)value).ToString("s");
            }
            return Convert.ToString(value, CultureInfo.InvariantCulture);
        }
    }
}
