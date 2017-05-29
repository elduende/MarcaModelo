using System.Collections.Generic;
using MarcaModelo.Entities;

namespace MarcaModelo.AppServices
{
    public interface IModeloCrudService
    {
        Marca GetMarca(string nameTemplate);
        IEnumerable<Modelo> GetAll(int IdMarca);
        Modelo Get(int IdModelo);
        void Remove(int IdModelo);
        string Save(Modelo modelo);
    }
}