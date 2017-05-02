using System;
using System.ComponentModel;

namespace MarcaModelo.WinForm.Common
{
    public class RelayCommand : ICommand
    {
        private readonly Func<bool> canExecute;
        private readonly Action execute;
        private bool? canExecuteState;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            this.execute = execute;
            this.canExecute = canExecute ?? (() => true);
        }

        public bool CanExecute
        {
            get
            {
                if (!canExecuteState.HasValue)
                {
                    canExecuteState = canExecute();
                }
                return canExecuteState.Value;
            }
            private set
            {
                if (!canExecuteState.HasValue || !Equals(canExecuteState, value))
                {
                    canExecuteState = value;
                    OnPropertyChanged("CanExecute");
                }
            }
        }

        public void Execute()
        {
            CheckCanExecute();
            if (CanExecute)
            {
                execute();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void CheckCanExecute()
        {
            CanExecute = canExecute();
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
