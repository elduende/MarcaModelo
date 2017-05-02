using System.Collections.Generic;
using System.ComponentModel;

namespace MarcaModelo.WinForm.Common
{
    public static class BindingListExtensions
    {
        public static void ReplaceAll<T>(this BindingList<T> source, IEnumerable<T> replacement)
        {
            if (source == null || replacement == null)
            {
                return;
            }
            source.RaiseListChangedEvents = false;
            try
            {
                source.Clear();
                foreach (var item in replacement)
                {
                    source.Add(item);
                }
            }
            finally
            {
                source.RaiseListChangedEvents = true;
                source.ResetBindings();
            }
        }
    }
}
