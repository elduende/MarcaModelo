using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using MarcaModelo.WinForm.Common.Attributes;

namespace MarcaModelo.WinForm.Common
{
    public class ValidatablePropertiesObject : ObservableObject, IDataErrorInfo
    {
        private string _error;

        public ValidatablePropertiesObject()
        {
            ValidationContext = new ValidationContext(this, null, null);
        }

        protected ValidationContext ValidationContext { get; }

        public virtual string this[string columnName] => this.PropertyError(ValidationContext, columnName);

        [Hidden]
        public string Error
        {
            get { return _error; }
            set { base.SetProperty(ref _error, value, nameof(Error)); }
        }

        protected override bool SetProperty<TProperty>(ref TProperty fieldOfProperty, TProperty value, [CallerMemberName] string propertyName = null)
        {
            var changed = base.SetProperty(ref fieldOfProperty, value, propertyName);
            if (changed)
            {
                Error = this.ModelError(ValidationContext);
            }
            return changed;
        }
    }
}
