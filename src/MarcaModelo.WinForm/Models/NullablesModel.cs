using MarcaModelo.WinForm.Common;

namespace MarcaModelo.WinForm.Models
{
    public class NullablesModel : ViewModelBase
    {
        private int? intValue;
        private double? doubleValue;

        public string IntValueEcho => intValue?.ToString() ?? "";
        public int? IntValue
        {
            get { return intValue; }
            set
            {
                if (SetProperty(ref intValue, value))
                {
                    OnPropertyChanged(nameof(IntValueEcho));
                }
            }
        }

        public string DoubleValueEcho => doubleValue?.ToString() ?? "";
        public double? DoubleValue
        {
            get { return doubleValue; }
            set
            {
                if (SetProperty(ref doubleValue, value))
                {
                    OnPropertyChanged(nameof(DoubleValueEcho));
                }
            }
        }
    }
}
