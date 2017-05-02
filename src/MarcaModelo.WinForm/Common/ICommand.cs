using System.ComponentModel;

namespace MarcaModelo.WinForm.Common
{
    public interface ICommand : INotifyPropertyChanged
    {
        bool CanExecute { get; }
        void Execute();
    }
}
