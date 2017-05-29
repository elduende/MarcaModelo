using System;

namespace MarcaModelo.Web.Common
{
    public class ViewModelBase : ValidatablePropertiesObject, IDisposable
    {
        private bool _isBusy;

        public virtual string Code
        {
            get { return GetType().Name; }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value, nameof(IsBusy)); }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public event EventHandler CloseRequest;

        public virtual bool CanClose()
        {
            return true;
        }

        protected virtual void OnCloseRequest()
        {
            var handler = CloseRequest;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Close()
        {
            OnCloseRequest();
        }
    }
}