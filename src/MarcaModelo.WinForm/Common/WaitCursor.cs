using System;
using System.Windows.Forms;

namespace MarcaModelo.WinForm.Common
{
    public class WaitCursor : IDisposable
    {
        private readonly Cursor oldCursor;

        public WaitCursor()
        {
            oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
        }

        public void Dispose()
        {
            Cursor.Current = oldCursor;
        }

        public static WaitCursor StartNew()
        {
            return new WaitCursor();
        }

        public static void Executing(Action method)
        {
            using (new WaitCursor())
            {
                method();
            }
        }
    }
}
