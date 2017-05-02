using System.Drawing;
namespace MarcaModelo.WinForm.Common
{
    public interface ICommandText : ICommand
    {
        string Text { get; }
        Color ForeColor { get; }
        Color BackgroundColor { get; }
    }
}
