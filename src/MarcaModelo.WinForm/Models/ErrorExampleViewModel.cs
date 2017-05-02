using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MarcaModelo.WinForm.Common;

namespace MarcaModelo.WinForm.Models
{
    public class ErrorExampleViewModel : ViewModelBase, IValidatableObject
    {
        private string name;
        private string surname;
        private readonly BindingList<MyItemViewModel> items = new BindingList<MyItemViewModel>();
        private bool esValido;
        private RelayCommand confirmarCommand;

        public ErrorExampleViewModel()
        {
            items.Add(new MyItemViewModel { Algo = "" });
            items.Add(new MyItemViewModel { Algo = "con algo" });
            items.Add(new MyItemViewModel { Algo = "     " });
            foreach (var item in items)
            {
                item.PropertyChanged += (sender, args) => { CheckIsValid(); };
            }
            PropertyChanged += (sender, args) => { CheckIsValid(); };
            confirmarCommand = new RelayCommand(() => Close(), () => EsValido);
        }

        [Required(ErrorMessage = "El nombre es un valor requerido")]
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value, nameof(Name)); }
        }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Surname
        {
            get { return surname; }
            set { SetProperty(ref surname, value, nameof(Surname)); }
        }

        private void CheckIsValid()
        {
            EsValido = this.IsValid(ValidationContext) && Items.All(x => x.IsValid());
        }

        private bool EsValido
        {
            get { return esValido; }
            set
            {
                if (SetProperty(ref esValido, value, () => EsValido))
                {
                    confirmarCommand.CheckCanExecute();
                }
            }
        }

        public ICommand ConfirmarCommand => confirmarCommand;

        public IEnumerable<MyItemViewModel> Items => items;

        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            if (context.IsForModel())
            {
                // Validaciones que no se quiere que se refieran a una propiedad especifica
                if (Surname == Name)
                {
                    yield return new ValidationResult("En nombre y el apellido no pueden ser iguales.");
                }
            }

            if (context.IsForModelOrForProperty(nameof(Name)) && !string.IsNullOrEmpty(Name) && Name.StartsWith(" "))
            {
                // Ejemplo : Agrega un error de una propiedad en Validate de el objeto
                yield return new ValidationResult("El nombre inicia con un espacio.", new[] { nameof(Name) });
            }
        }
    }

    public class MyItemViewModel : ValidatablePropertiesObject, IValidatableObject
    {
        private string algo;
        private int maxValue;
        private int minValue;

        [Required]
        public string Algo
        {
            get { return algo; }
            set { SetProperty(ref algo, value, nameof(Algo)); }
        }

        [Range(0, 1000)]
        public int MinValue
        {
            get { return minValue; }
            set { SetProperty(ref minValue, value, nameof(MinValue)); }
        }

        [Range(0, 2000)]
        public int MaxValue
        {
            get { return maxValue; }
            set { SetProperty(ref maxValue, value, nameof(MaxValue)); }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            if (MinValue >= MaxValue)
            {
                yield return new ValidationResult("El valor minimo tiene que ser inferior al maximo.");
            }
        }
    }
}
