using System;

namespace MarcaModelo.Services
{
    public interface IServiceContainer : IDisposable
    {
        T GetInstance<T>() where T : class;
        object GetInstance(Type type);
    }
}
