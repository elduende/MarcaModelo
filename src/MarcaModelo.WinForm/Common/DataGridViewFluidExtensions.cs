using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using MarcaModelo.WinForm.Common.Attributes;

namespace MarcaModelo.WinForm.Common
{
    public static class DataGridViewFluidExtensions
    {
        public static DataGridViewColumn Readonly(this DataGridViewColumn source)
        {
            source.ReadOnly = true;
            return source;
        }

        public static DataGridViewColumn Hidden(this DataGridViewColumn source)
        {
            source.Visible = false;
            return source;
        }

        public static DataGridViewColumn Frozen(this DataGridViewColumn source)
        {
            source.Frozen = true;
            return source;
        }

        public static DataGridViewColumn Sortable(this DataGridViewColumn source)
        {
            source.SortMode = DataGridViewColumnSortMode.Programmatic;
            return source;
        }

        public static DataGridViewColumn With(this DataGridViewColumn source, Action<DataGridViewColumn> setting)
        {
            if (setting == null)
            {
                return source;
            }
            setting(source);
            return source;
        }

        public static DataGridView BindSource<TModel, TElement>(this DataGridView control, TModel model, Expression<Func<TModel, IEnumerable<TElement>>> dataSource)
        {
            control.DataSource = dataSource.Compile().Invoke(model);
            return control;
        }

        public static DataGridViewColumn Bind<TItemModel>(this DataGridViewColumn source, Expression<Func<TItemModel, object>> value, Func<string, string> displayNameModifier = null)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            var displayMod = displayNameModifier ?? (x => x);
            var propName = GetPlainPropertyName(source, value);
            var propertyDescriptor = TypeDescriptor.GetProperties(typeof(TItemModel))[propName];
            if (string.IsNullOrEmpty(source.HeaderText))
            {
                source.HeaderText = displayMod(propertyDescriptor.DisplayName);
            }
            source.DataPropertyName = propertyDescriptor.Name;
            source.ValueType = propertyDescriptor.PropertyType;
            source.ReadOnly = propertyDescriptor.IsReadOnly;

            var dataaFormat = propertyDescriptor.Attributes.OfType<DisplayFormatAttribute>().FirstOrDefault();
            if (dataaFormat != null)
            {
                source.DefaultCellStyle.Format = dataaFormat.DataFormatString;
            }
            var visibleAttribute = propertyDescriptor.Attributes.OfType<HiddenAttribute>().FirstOrDefault();
            if (visibleAttribute != null)
            {
                source.Visible = visibleAttribute.Visible;
            }
            return source;
        }

        private static string GetPlainPropertyName<TModel>(DataGridViewColumn control, Expression<Func<TModel, object>> expression)
        {
            MemberExpression memberExpression = null;

            if (expression.Body.NodeType == ExpressionType.Convert)
            {
                memberExpression = ((UnaryExpression)expression.Body).Operand as MemberExpression;
            }
            else if (expression.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpression = expression.Body as MemberExpression;
            }

            if (memberExpression == null)
            {
                throw new NotSupportedException($"Expresión de Bind DataGridViewColumn control ({control.Name}) no soportada.");
            }
            return memberExpression.Member.Name;
        }
    }
}
