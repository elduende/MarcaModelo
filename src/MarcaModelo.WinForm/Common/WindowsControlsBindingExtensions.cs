using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MarcaModelo.WinForm.Common
{
    public static class WindowsControlsBindingExtensions
    {
        private static readonly NumberStyles IntegerNumberStyles = NumberStyles.AllowLeadingSign | NumberStyles.AllowLeadingWhite;

        public static void Bind(this Form control, ViewModelBase model)
        {
            if (model == null)
            {
                return;
            }
            model.CloseRequest += (sender, args) => control.Close();
            control.Closing += (sender, args) =>
            {
                args.Cancel = !model.CanClose();
            };
            control.FormClosed += (sender, args) => model.Dispose();
            model.PropertyChanged += (sender, args) =>
            {
                if (nameof(ViewModelBase.IsBusy).Equals(args.PropertyName))
                {
                    Cursor.Current = model.IsBusy ? Cursors.WaitCursor : Cursors.Arrow;
                }
            };
        }

        public static void BindKey(this Form control, Keys key, ICommand command, bool keyPreview = true)
        {
            control.KeyPreview = keyPreview;
            control.KeyDown += (sender, args) =>
            {
                if (args.KeyCode != key)
                {
                    return;
                }
                command.Execute();
                args.Handled = true;
            };
        }

        public static void Bind(this Button control, ICommandText command)
        {
            control.DataBindings.Add("Enabled", command, "CanExecute");
            control.DataBindings.Add("Text", command, "Text");
            control.DataBindings.Add("ForeColor", command, "ForeColor");
            control.Click += (o, e) => command.Execute();
        }

        public static void Bind(this Button control, ICommand command, [Optional] bool executeWaiting)
        {
            command.PropertyChanged += (sender, args) =>
            {
                if ("CanExecute".Equals(args.PropertyName))
                {
                    control.ThreadSafeInvoke(() => control.Enabled = command.CanExecute);
                }
            };
            control.Enabled = command.CanExecute;
            if (executeWaiting)
            {
                control.Click += (o, e) => WaitCursor.Executing(() => command.Execute());
            }
            else
            {
                control.Click += (o, e) => command.Execute();
            }
        }

        public static Button BindErrors<TModel>(this Button control, TModel model, ErrorProvider errorProvider) where TModel : IDataErrorInfo, INotifyPropertyChanged
        {
            model.PropertyChanged += (sender, args) =>
            {
                if (nameof(IDataErrorInfo.Error).Equals(args.PropertyName))
                {
                    control.ThreadSafeInvoke(() => errorProvider.SetError(control, model.Error));
                }
            };
            errorProvider.SetError(control, model.Error);
            return control;
        }

        public static void BindVisibility(this Button control, ICommand command, [Optional] bool executeWaiting)
        {
            command.PropertyChanged += (sender, args) =>
            {
                if (nameof(ICommand.CanExecute).Equals(args.PropertyName))
                {
                    control.ThreadSafeInvoke(() => control.Visible = command.CanExecute);
                }
            };
            control.Visible = command.CanExecute;
            if (executeWaiting)
            {
                control.Click += (o, e) => WaitCursor.Executing(() => command.Execute());
            }
            else
            {
                control.Click += (o, e) => command.Execute();
            }
        }

        public static void Bind(this ToolStripStatusLabel control, ICommandText command)
        {
            control.Text = command.Text;
            control.ForeColor = command.ForeColor;
            control.Enabled = command.CanExecute;
            control.Click += (o, e) => command.Execute();
            command.PropertyChanged += (sender, args) =>
            {
                if ("Text".Equals(args.PropertyName))
                {
                    control.Text = command.Text;
                }
                else if ("ForeColor".Equals(args.PropertyName))
                {
                    control.ForeColor = command.ForeColor;
                }
                else if ("CanExecute".Equals(args.PropertyName))
                {
                    control.Enabled = command.CanExecute;
                }
            };
        }

        public static void Bind(this ToolStripMenuItem control, ICommandText command)
        {
            control.Text = command.Text;
            control.ForeColor = command.ForeColor;
            control.Enabled = command.CanExecute;
            control.Click += (o, e) => command.Execute();
            command.PropertyChanged += (sender, args) =>
            {
                if ("Text".Equals(args.PropertyName))
                {
                    control.Text = command.Text;
                }
                else if ("ForeColor".Equals(args.PropertyName))
                {
                    control.ForeColor = command.ForeColor;
                }
                else if ("CanExecute".Equals(args.PropertyName))
                {
                    control.Enabled = command.CanExecute;
                }
            };
        }

        public static void Bind(this ToolStripMenuItem control, ICommand command, [Optional] bool executeWaiting)
        {
            control.Enabled = command.CanExecute;
            if (executeWaiting)
            {
                control.Click += (o, e) => WaitCursor.Executing(() => command.Execute());
            }
            else
            {
                control.Click += (o, e) => command.Execute();
            }
            command.PropertyChanged += (sender, args) =>
            {
                if ("CanExecute".Equals(args.PropertyName))
                {
                    control.Enabled = command.CanExecute;
                }
            };
        }

        public static void BindValue<TModel, TProperty>(this TextBox control, TModel model, Expression<Func<TModel, TProperty>> value, DataSourceUpdateMode mode = DataSourceUpdateMode.OnPropertyChanged)
        {
            var propertyName = GetPlainPropertyName(control, value);
            control.DataBindings.Add("Text", model, propertyName, false, mode);
        }

        public static void BindValue<TModel>(this TextBox control, TModel model, Expression<Func<TModel, int?>> value, string format = null)
            where TModel : INotifyPropertyChanged
        {
            var prop = GetPlainProperty(control, value);
            var setter = prop.GetSetMethod();
            var getter = prop.GetGetMethod();
            control.TextChanged += (s, a) =>
            {
                if (setter != null)
                {
                    var pvalue = TextToIntTransformer(control.Text);
                    setter.Invoke(model, new object[] { pvalue });
                }
            };
            model.PropertyChanged += (_, args) =>
            {
                if (prop.Name.Equals(args.PropertyName))
                {
                    var pvalue = (int?)getter.Invoke(model, null);
                    control.Text = NullableToTextTrasformer(pvalue, format);
                }
            };
            control.Text = NullableToTextTrasformer((int?)getter.Invoke(model, null), format);
        }

        public static void BindValue<TModel>(this TextBox control, TModel model, Expression<Func<TModel, double?>> value, string format = null)
            where TModel : INotifyPropertyChanged
        {
            var prop = GetPlainProperty(control, value);
            var setter = prop.GetSetMethod();
            var getter = prop.GetGetMethod();
            control.TextChanged += (s, a) =>
            {
                if (setter != null)
                {
                    var pvalue = TextToDoubleTransformer(control.Text);
                    setter.Invoke(model, new object[] { pvalue });
                }
            };
            model.PropertyChanged += (_, args) =>
            {
                if (prop.Name.Equals(args.PropertyName))
                {
                    var pvalue = (double?)getter.Invoke(model, null);
                    control.Text = NullableToTextTrasformer(pvalue, format);
                }
            };
            control.Text = NullableToTextTrasformer((double?)getter.Invoke(model, null), format);
        }

        private static int? TextToIntTransformer(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return null;
            }
            var toconvert = PrepareStringToConvertNumber(source);
            int result;
            return int.TryParse(toconvert, IntegerNumberStyles, CultureInfo.CurrentUICulture, out result) ? result : (int?)null;
        }

        private static double? TextToDoubleTransformer(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return null;
            }
            var toconvert = PrepareStringToConvertNumber(source);
            double result;
            return double.TryParse(toconvert, IntegerNumberStyles, CultureInfo.CurrentUICulture, out result) ? result : (double?)null;
        }

        private static string PrepareStringToConvertNumber(string source)
        {
            var toconvert = source.Trim();
            char leadingSign = toconvert[0];
            var hasLeadingSign = '+'.Equals(leadingSign) || '-'.Equals(leadingSign);
            return !hasLeadingSign ? toconvert : string.Concat(leadingSign.ToString(), toconvert.Substring(1).TrimStart());
        }

        private static string NullableToTextTrasformer(int? value, string format = null)
        {
            if (string.IsNullOrEmpty(format))
            {
                return value?.ToString() ?? "";
            }
            return value?.ToString(format) ?? "";
        }

        private static string NullableToTextTrasformer(double? value, string format = null)
        {
            if (string.IsNullOrEmpty(format))
            {
                return value?.ToString() ?? "";
            }
            return value?.ToString(format) ?? "";
        }

        public static void BindValue<TModel>(this MaskedTextBox control, TModel model, Expression<Func<TModel, DateTime?>> value)
        {
            var expression = value.Body as MemberExpression;
            var property = expression != null ? expression.Member as PropertyInfo : null;
            if (property == null)
            {
                return;
            }
            control.Mask = @"99/99/99";
            control.TextMaskFormat = MaskFormat.IncludeLiterals;
            control.AsciiOnly = true;
            control.AllowPromptAsInput = false;
            control.Culture = CultureInfo.CurrentUICulture;
            var propValue = property.GetValue(model, null);
            control.Text = propValue == null ? "" : string.Format("{0:dd/MM/yy}", propValue);
            var setter = property.GetSetMethod();
            if (setter != null)
            {
                control.Validated += (sender, args) =>
                {
                    var text = control.Text;
                    DateTime newValue;
                    if (string.IsNullOrWhiteSpace(text) || !DateTime.TryParse(text, out newValue))
                    {
                        setter.Invoke(model, new object[] { null });
                    }
                    else
                    {
                        setter.Invoke(model, new object[] { newValue });
                    }
                };
            }
            var propChanged = model as INotifyPropertyChanged;
            if (propChanged != null)
            {
                propChanged.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName.Equals(property.Name))
                    {
                        var pv = property.GetValue(model, null);
                        control.Text = pv == null ? "" : string.Format("{0:dd/MM/yy}", pv);
                    }
                };
            }
        }

        public static void BindValue<TModel>(this MaskedTextBox control, TModel model, Expression<Func<TModel, DateTime>> value)
        {
            var expression = value.Body as MemberExpression;
            var property = expression != null ? expression.Member as PropertyInfo : null;
            if (property == null)
            {
                return;
            }
            control.Mask = @"99/99/99";
            control.TextMaskFormat = MaskFormat.IncludeLiterals;
            control.AsciiOnly = true;
            control.AllowPromptAsInput = false;
            control.Culture = CultureInfo.CurrentUICulture;
            var propValue = property.GetValue(model, null);
            control.Text = propValue == null ? "" : string.Format("{0:dd/MM/yy}", propValue);
            var setter = property.GetSetMethod();
            if (setter != null)
            {
                control.Validated += (sender, args) =>
                {
                    var text = control.Text;
                    DateTime newValue;
                    if (string.IsNullOrWhiteSpace(text) || !DateTime.TryParse(text, out newValue))
                    {
                        control.Text = DateTime.MinValue.ToString("dd/MM/yy");
                        setter.Invoke(model, new object[] { DateTime.MinValue });
                    }
                    else
                    {
                        setter.Invoke(model, new object[] { newValue });
                    }
                };
            }
            var propChanged = model as INotifyPropertyChanged;
            if (propChanged != null)
            {
                propChanged.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName.Equals(property.Name))
                    {
                        var pv = property.GetValue(model, null);
                        control.Text = pv == null ? "" : string.Format("{0:dd/MM/yy}", pv);
                    }
                };
            }
        }

        public static void BindValue<TModel, TProperty>(this Label control, TModel model, Expression<Func<TModel, TProperty>> value)
        {
            var propertyName = GetPlainPropertyName(control, value);
            control.DataBindings.Add("Text", model, propertyName);
        }

        public static void BindValue<TModel, TProperty>(this Label control, TModel model, Expression<Func<TModel, TProperty>> value, string format)
        {
            var propertyName = GetPlainPropertyName(control, value);
            control.DataBindings.Add("Text", model, propertyName, true, DataSourceUpdateMode.OnPropertyChanged, null, format);
        }

        public static void BindVisibility<TModel>(this Label control, TModel model, Expression<Func<TModel, bool>> value)
        {
            var propertyName = GetPlainPropertyName(control, value);
            control.DataBindings.Add("Visible", model, propertyName);
        }

        public static void BindVisibility<TModel>(this ProgressBar control, TModel model, Expression<Func<TModel, bool>> value)
        {
            var propertyName = GetPlainPropertyName(control, value);
            control.DataBindings.Add("Visible", model, propertyName);
        }

        public static void BindValues<TModel>(this ProgressBar control, TModel model, Expression<Func<TModel, int>> maximum, Expression<Func<TModel, int>> value)
        {
            var propertyName = GetPlainPropertyName(control, value);
            var maximumPropertyName = GetPlainPropertyName(control, maximum);
            control.DataBindings.Add("Maximum", model, maximumPropertyName);
            control.DataBindings.Add("Value", model, propertyName);
        }

        public static void BindValue<TModel>(this CheckBox control, TModel model, Expression<Func<TModel, bool>> value)
        {
            var propertyName = GetPlainPropertyName(control, value);
            control.DataBindings.Add("Checked", model, propertyName);
        }

        public static TextBox AsIntegerInput(this TextBox control, int maxDigits = 9)
        {
            control.KeyPress += (sender, e) =>
            {
                if (char.IsDigit(e.KeyChar)
                        || (e.KeyChar == (char)Keys.Tab)
                        || (e.KeyChar == (char)Keys.Back)
                        || ((Control.ModifierKeys & (Keys.Control | Keys.Alt)) != Keys.None))
                {
                    return;
                }
                e.Handled = true;
            };
            control.TextAlign = HorizontalAlignment.Right;
            control.MaxLength = maxDigits;
            return control;
        }

        public static TextBox AsDecimalInput(this TextBox control)
        {
            control.KeyPress += (sender, e) =>
            {
                if (char.IsDigit(e.KeyChar)
                        || (e.KeyChar == (char)Keys.Tab)
                        || (e.KeyChar == (char)Keys.Back)
                        || ((Control.ModifierKeys & (Keys.Control | Keys.Alt)) != Keys.None))
                {
                    return;
                }
                if ((e.KeyChar == ',') || (e.KeyChar == '.'))
                {
                    if ((sender as TextBox).Text.IndexOf(e.KeyChar) == -1)
                    {
                        return;
                    }
                }
                e.Handled = true;
            };
            control.TextAlign = HorizontalAlignment.Right;
            return control;
        }

        public static void BindValue<TModel, TProperty>(this NumericUpDown control, TModel model, Expression<Func<TModel, TProperty>> value, DataSourceUpdateMode mode = DataSourceUpdateMode.OnPropertyChanged)
        {
            var expression = value.Body as MemberExpression;
            if (expression == null)
            {
                throw new NotSupportedException(string.Format("Expresión de Bind NumericUpDown control ({0}) no suportada.", control.Name));
            }
            var propertyName = expression.Member.Name;
            control.DataBindings.Add("Value", model, propertyName, false, mode);
        }

        public static void BindValue<TModel, TProperty>(this DateTimePicker control, TModel model, Expression<Func<TModel, TProperty>> value, DataSourceUpdateMode mode = DataSourceUpdateMode.OnPropertyChanged)
        {
            var expression = value.Body as MemberExpression;
            if (expression == null)
            {
                throw new NotSupportedException(string.Format("Expresión de Bind DateTimePicker control ({0}) no suportada.", control.Name));
            }
            var propertyName = expression.Member.Name;
            control.DataBindings.Add("Value", model, propertyName, false, mode);
        }

        public static ComboBox BindValue<TModel, TProperty>(this ComboBox control, TModel model, Expression<Func<TModel, TProperty>> value, DataSourceUpdateMode mode = DataSourceUpdateMode.OnPropertyChanged)
        {
            var propertyName = GetPlainPropertyName(control, value);
            control.DataBindings.Add("SelectedValue", model, propertyName, false, mode);
            return control;
        }

        public static void BindSource<TModel, TElement, TPropertyDesc, TPropertyValue>(this ComboBox control, TModel model,
            Expression<Func<TModel, IEnumerable<TElement>>> dataSource
            , Expression<Func<TElement, TPropertyValue>> valueProp
            , Expression<Func<TElement, TPropertyDesc>> descriptionProp)
        {
            if (valueProp == null)
            {
                throw new ArgumentNullException(nameof(valueProp));
            }
            if (descriptionProp == null)
            {
                throw new ArgumentNullException(nameof(descriptionProp));
            }
            control.DisplayMember = GetPlainPropertyName(control, descriptionProp);
            control.ValueMember = GetPlainPropertyName(control, valueProp);
            control.DataSource = dataSource.Compile().Invoke(model);
        }

        public static void BindAutocomplete<TModel, TElement, TPropertyDesc, TPropertyValue>(this ComboBox control, TModel model,
            Expression<Func<TModel, IEnumerable<TElement>>> dataSource
            , Expression<Func<TElement, TPropertyValue>> valueProp
            , Expression<Func<TElement, TPropertyDesc>> descriptionProp)
        {
            control.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            control.AutoCompleteSource = AutoCompleteSource.ListItems;
            control.DropDownStyle = ComboBoxStyle.DropDown;
            BindSource(control, model, dataSource, valueProp, descriptionProp);
        }

        public static void BindPressEnter(this Control control, ICommand command, bool executeWaiting = false)
        {
            control.KeyPress += (sender, args) =>
            {
                if (args.KeyChar != (char)Keys.Return)
                {
                    return;
                }
                if (executeWaiting)
                {
                    WaitCursor.Executing(() => command.Execute());
                }
                else
                {
                    command.Execute();
                }
            };
        }

        public static void AddSystemDefaultsEventLevelImages(this ImageList control)
        {
            control.Images.Add("Information", SystemIcons.Information);
            control.Images.Add("Error", SystemIcons.Error);
            control.Images.Add("Warning", SystemIcons.Exclamation);
        }

        private static string GetPlainPropertyName<TModel, TProperty>(Control control, Expression<Func<TModel, TProperty>> expression)
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
                throw new NotSupportedException(string.Format("Expresión de Bind {0} control ({1}) no suportada.", control.GetType().Name, control.Name));
            }

            return memberExpression.Member.Name;
        }

        private static PropertyInfo GetPlainProperty<TModel, TProperty>(Control control, Expression<Func<TModel, TProperty>> expression)
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

            if (memberExpression == null || memberExpression.Member.MemberType != MemberTypes.Property)
            {
                throw new NotSupportedException(string.Format("Expresión de Bind {0} control ({1}) no suportada.", control.GetType().Name, control.Name));
            }

            return (PropertyInfo)memberExpression.Member;
        }

        public static void ThreadSafeInvoke(this Control source, Action method)
        {
            if (source.InvokeRequired)
            {
                source.BeginInvoke(method);
            }
            else
            {
                method();
            }
        }
    }
}
