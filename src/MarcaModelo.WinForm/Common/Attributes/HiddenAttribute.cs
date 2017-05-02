using System;

namespace MarcaModelo.WinForm.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class HiddenAttribute : Attribute
    {
        public HiddenAttribute(bool hidden = true)
        {
            Visible = !hidden;
        }

        public bool Visible { get; }
    }
}
