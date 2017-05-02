using System;

namespace MarcaModelo.WinForm.Common
{
    public interface IViewModelExposer : IDisposable
    {
        void Expose(ViewModelBase viewModel);
        void ExposeSync(ViewModelBase viewModel);

        /// <summary>
        /// Expose the view model tryining to create it berore expose.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the viewmodel</typeparam>
        /// <param name="initialize">The action to execute before give the viewmodel to the view.</param>
        void Expose<TViewModel>(Action<TViewModel> initialize = null) where TViewModel : ViewModelBase;

        /// <summary>
        /// Expose Sync (Dialog) the view model tryining to create it berore expose.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the viewmodel</typeparam>
        /// <param name="initialize">The action to execute before give the viewmodel to the view.</param>
        void ExposeSync<TViewModel>(Action<TViewModel> initialize = null) where TViewModel : ViewModelBase;
    }
}
