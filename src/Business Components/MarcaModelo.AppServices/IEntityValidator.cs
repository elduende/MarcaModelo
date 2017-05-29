using System;
using System.Collections.Generic;

namespace MarcaModelo.AppServices
{
    public interface IEntityValidator
    {
        bool IsValid(object entityInstance);
        IList<IInvalidValueInfo> Validate(object entityInstance);
        //IList<IInvalidValueInfo> Validate<T, TP>(T entityInstance, Expression<Func<T, TP>> property) where T : class;
        IList<IInvalidValueInfo> Validate(object entityInstance, string propertyName);
    }

    public interface IInvalidValueInfo
    {
        Type EntityType { get; }
        string PropertyName { get; }
        string Message { get; }
    }
}
