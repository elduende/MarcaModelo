using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace MarcaModelo.WinForm.Common
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<TProperty>(ref TProperty storage, TProperty value, Expression<Func<TProperty>> propertyExpression)
        {
            string propertyName = GetPropertyName(propertyExpression);
            return SetProperty(ref storage, value, propertyName);
        }

        protected virtual bool SetProperty<TProperty>(ref TProperty fieldOfProperty, TProperty value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<TProperty>.Default.Equals(fieldOfProperty, value))
            {
                return false;
            }
            fieldOfProperty = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private string GetPropertyName<TProperty>(Expression<Func<TProperty>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            if (expression.Body.NodeType != ExpressionType.MemberAccess)
            {
                throw new NotSupportedException("Se espera una expresión lambda que representa una propiedad.");
            }

            return ((MemberExpression)expression.Body).Member.Name;
        }
    }
}
