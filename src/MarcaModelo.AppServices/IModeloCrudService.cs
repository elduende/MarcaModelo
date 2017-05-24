using System.Collections.Generic;
using MarcaModelo.Data;

namespace MarcaModelo.AppServices
{
    public interface IModeloCrudService
    {
        IEnumerable<Modelo> Modelos();
        Modelo GetById(int IDModelo);
        void Desactivar(int IDMarca);
        void Activar(int IDMarca);
        IEnumerable<IInvalidValueInfo> Persist(Modelo modelo);
        //void Persist(Modelo modelo);
        Marca Marca { get; set; }
    }
}
