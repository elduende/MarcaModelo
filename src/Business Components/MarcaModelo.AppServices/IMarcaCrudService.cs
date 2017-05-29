using System.Collections.Generic;
using MarcaModelo.Entities;

namespace MarcaModelo.AppServices
{
    public interface IMarcaCrudService
    {
        IEnumerable<Marca> GetAll(string nameTemplate, int pageNumber, int pageSize);
        Marca Get(int idMarca);
        void Remove(int idMarca);
        string Save(Marca marca);
    }
}
