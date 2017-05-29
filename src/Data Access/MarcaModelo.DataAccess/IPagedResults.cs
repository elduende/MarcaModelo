using System.Collections.Generic;

namespace MarcaModelo.DataAccess
{
    public interface IPagedResults<T>
    {
        int Count { get; }
        IEnumerable<T> Results { get; }
    }
}
