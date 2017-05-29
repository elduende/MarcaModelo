using System.Collections.Generic;
using MarcaModelo.Entities;

namespace MarcaModelo.AppServices
{
    public interface IModeloCrudService
    {
        Marca GetMarca(string nameTemplate);
        IEnumerable<Modelo> GetAll(int idMarca);
        Modelo Get(int idModelo);
        void Remove(int idModelo);
        string Save(Modelo modelo);
    }
}