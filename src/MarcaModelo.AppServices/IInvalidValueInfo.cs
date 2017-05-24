using System;

namespace MarcaModelo.AppServices
{
    public interface IInvalidValueInfo
    {
        Type EntityType { get; }
        string PropertyName { get; }
        string Message { get; }
    }
}
