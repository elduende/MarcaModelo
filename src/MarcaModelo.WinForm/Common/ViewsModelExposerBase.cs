using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MarcaModelo.WinForm.Common
{
    public class ViewsModelExposerBase : IViewModelExposer
    {
        private readonly Dictionary<string, Func<ViewModelBase>> modelCtors =
            new Dictionary<string, Func<ViewModelBase>>();

        private readonly Dictionary<string, Func<ViewModelBase, Form>> formCtors =
            new Dictionary<string, Func<ViewModelBase, Form>>();

        private readonly Dictionary<string, Action<ViewModelBase>> messageBoxesCtors =
            new Dictionary<string, Action<ViewModelBase>>();

        private ConcurrentDictionary<Type, Form> singletons = new ConcurrentDictionary<Type, Form>();
        private Func<Type, ViewModelBase> generaViewModelsFactory;

        public ViewsModelExposerBase()
        {
            messageBoxesCtors.Add(typeof(ErrorMessageViewModel).Name, x => ShowErrorMessageBox((ErrorMessageViewModel)x));
            messageBoxesCtors.Add(typeof(YesNoQuestionViewModel).Name, x => ShowQuestionMessageBox((YesNoQuestionViewModel)x));
        }

        public void UseViewModelsFactory(Func<Type, ViewModelBase> ctor)
        {
            if (ctor == null)
            {
                throw new ArgumentNullException(nameof(ctor));
            }
            if (generaViewModelsFactory != null)
            {
                throw new NotSupportedException("No es posible registrar más de un object factory.");
            }
            generaViewModelsFactory = ctor;
        }

        public void Register<TViewModel>(Func<TViewModel, Form> formCtor) where TViewModel : ViewModelBase
        {
            if (formCtor == null)
            {
                throw new ArgumentNullException(nameof(formCtor));
            }
            formCtors.Add(typeof(TViewModel).Name, x => formCtor((TViewModel)x));
        }

        public void Register<TViewModel, TForm>()
            where TViewModel : ViewModelBase
            where TForm : Form
        {
            var ctor = typeof(TForm).GetConstructor(new[] { typeof(TViewModel) });
            if (ctor == null)
            {
                throw new NotSupportedException($"Intenta registrar un Form que no pose un constructor con solo '{typeof(TViewModel).Name}'. Use otro metodo de registración que le permite especificar el constructor del Form '{typeof(TForm).Name}'.");
            }
            formCtors.Add(typeof(TViewModel).Name, x => (TForm)Activator.CreateInstance(typeof(TForm), x));
        }

        public ViewsModelExposerBase RegisterSingletonForm<TViewModel, TForm>(Func<TViewModel, TForm> ctor)
            where TViewModel : ViewModelBase
            where TForm : Form
        {
            formCtors.Add(typeof(TViewModel).Name, viewModel => ActivateForm(() => ctor((TViewModel)viewModel)));
            return this;
        }

        public void Register<TViewModel>(Func<TViewModel> modelCtor, Func<TViewModel, Form> formCtor) where TViewModel : ViewModelBase
        {
            if (modelCtor == null)
            {
                throw new ArgumentNullException(nameof(modelCtor));
            }
            if (formCtor == null)
            {
                throw new ArgumentNullException(nameof(formCtor));
            }
            var key = typeof(TViewModel).Name;
            modelCtors.Add(key, modelCtor);
            formCtors.Add(key, x => formCtor((TViewModel)x));
        }

        public void Register<TViewModel, TForm>(Func<TViewModel> modelCtor)
            where TViewModel : ViewModelBase
            where TForm : Form
        {
            if (modelCtor == null)
            {
                throw new ArgumentNullException(nameof(modelCtor));
            }
            var ctor = typeof(TForm).GetConstructor(new[] { typeof(TViewModel) });
            if (ctor == null)
            {
                throw new NotSupportedException($"Intenta registrar un Form que no pose un constructor con solo '{typeof(TViewModel).Name}'. Use otro metodo de registración que le permite especificar el constructor del Form '{typeof(TForm).Name}'.");
            }
            var key = typeof(TViewModel).Name;
            modelCtors.Add(key, modelCtor);
            formCtors.Add(key, x => (TForm)Activator.CreateInstance(typeof(TForm), x));
        }

        public Form Owner { get; set; }

        public void Expose(ViewModelBase viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException("viewModel");
            }
            Func<ViewModelBase, Form> ctor;
            if (!formCtors.TryGetValue(viewModel.Code, out ctor))
            {
                throw new ArgumentOutOfRangeException("viewModel",
                    string.Format("ViewModel no gestionado.(Code='{0}')", viewModel.Code));
            }
            try
            {
                var form = ctor(viewModel);
                if (!form.Visible)
                {
                    if (Owner != null)
                    {
                        form.Show(Owner);
                    }
                    else
                    {
                        form.Show();
                    }
                }
                else
                {
                    form.Focus();
                }
            }
            catch (InvalidCastException e)
            {
                throw new ArgumentOutOfRangeException("viewModel",
                    string.Format("El formulario no admite el viewmodel (Code='{0}'): {1}",
                        viewModel.Code, e.Message));
            }
        }

        public void ExposeSync(ViewModelBase viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException("viewModel");
            }
            Action<ViewModelBase> msgBoxExposer;
            if (messageBoxesCtors.TryGetValue(viewModel.Code, out msgBoxExposer))
            {
                msgBoxExposer(viewModel);
                return;
            }
            Func<ViewModelBase, Form> ctor;
            if (!formCtors.TryGetValue(viewModel.Code, out ctor))
            {
                throw new ArgumentOutOfRangeException("viewModel",
                    string.Format("ViewModel no gestionado.(Code='{0}')", viewModel.Code));
            }
            try
            {
                var form = ctor(viewModel);
                if (!form.Visible)
                {
                    if (Owner != null)
                    {
                        form.ShowDialog(Owner);
                    }
                    else
                    {
                        form.ShowDialog();
                    }
                }
                else
                {
                    form.Focus();
                }
            }
            catch (InvalidCastException e)
            {
                throw new ArgumentOutOfRangeException("viewModel",
                    string.Format("El formulario no admite el viewmodel (Code='{0}'): {1}",
                        viewModel.Code, e.Message));
            }
        }

        public void Expose<TViewModel>(Action<TViewModel> initialize = null) where TViewModel : ViewModelBase
        {
            var viewModelInstance = GetViewModelInstace<TViewModel>();
            initialize?.Invoke(viewModelInstance);
            Expose(viewModelInstance);
        }

        public void ExposeSync<TViewModel>(Action<TViewModel> initialize = null) where TViewModel : ViewModelBase
        {
            var viewModelInstance = GetViewModelInstace<TViewModel>();
            initialize?.Invoke(viewModelInstance);
            ExposeSync(viewModelInstance);
        }

        private TViewModel GetViewModelInstace<TViewModel>() where TViewModel : ViewModelBase
        {
            Func<ViewModelBase> ctor;
            if (modelCtors.TryGetValue(typeof(TViewModel).Name, out ctor))
            {
                return (TViewModel)ctor();
            }
            // Usa el general factory o intenta crear el viewmodel usando el constructor sin parametros
            return (TViewModel)generaViewModelsFactory?.Invoke(typeof(TViewModel)) ?? Activator.CreateInstance<TViewModel>();
        }

        private void ShowErrorMessageBox(ErrorMessageViewModel errorMessageViewModel)
        {
            MessageBox.Show(errorMessageViewModel.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowQuestionMessageBox(YesNoQuestionViewModel model)
        {
            model.Accepted = MessageBox.Show(model.Question, model.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
        }

        private Form ActivateForm<TForm>(Func<TForm> ctor) where TForm : Form
        {
            Form activateForm;
            var exists = singletons.TryGetValue(typeof(TForm), out activateForm);
            if (!exists || activateForm.IsDisposed)
            {
                activateForm = ctor();
                singletons.TryAdd(typeof(TForm), activateForm);
                activateForm.Closed += (sender, args) =>
                {
                    Form trush;
                    singletons.TryRemove(typeof(TForm), out trush);
                };
            }
            return activateForm;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (singletons != null)
                {
                    foreach (var singleton in singletons.Values)
                    {
                        try
                        {
                            singleton.Close();
                            singleton.Dispose();
                        }
                        catch (Exception)
                        {
                            // TODO: trace possible leaks
                        }
                    }
                    singletons = null;
                }
            }
        }
    }
}
