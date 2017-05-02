using System;
using MarcaModelo.WinForm.Common;

namespace MarcaModelo.WinFormTests
{
    public class NoOpViewModelExposer
    {
        public void Expose(ViewModelBase viewModel) { }
        public void ExposeSync(ViewModelBase viewModel) { }
        public void Expose<TViewModel>(Action<TViewModel> initialize = null) where TViewModel : ViewModelBase { }
        public void ExposeSync<TViewModel>(Action<TViewModel> initialize = null) where TViewModel : ViewModelBase { }
        public void Dispose() { }
    }
}
