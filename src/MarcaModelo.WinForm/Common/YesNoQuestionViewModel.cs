namespace MarcaModelo.WinForm.Common
{
    public class YesNoQuestionViewModel : ViewModelBase
    {
        public string Title { get; set; }
        public string Question { get; set; }
        public bool Accepted { get; set; }
        public bool Refused => !Accepted;
    }
}
