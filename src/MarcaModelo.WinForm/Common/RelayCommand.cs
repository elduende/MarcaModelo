using System;
using System.ComponentModel;

namespace MarcaModelo.WinForm.Common
{
    public class RelayCommand : ICommand
    {
        private readonly Func<bool> _canExecute;
        private readonly Action _execute;
        private bool? _canExecuteState;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            this._execute = execute;
            this._canExecute = canExecute ?? (() => true);
        }

        public bool CanExecute
        {
            get
            {
                if (!_canExecuteState.HasValue)
                {
                    _canExecuteState = _canExecute();
                }
                return _canExecuteState.Value;
            }
            private set
            {
                if (!_canExecuteState.HasValue || !Equals(_canExecuteState, value))
                {
                    _canExecuteState = value;
                    OnPropertyChanged("CanExecute");
                }
            }
        }

        public void Execute()
        {
            CheckCanExecute();
            if (CanExecute)
            {
                _execute();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void CheckCanExecute()
        {
            CanExecute = _canExecute();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
