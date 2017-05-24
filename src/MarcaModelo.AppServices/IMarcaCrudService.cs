using System.Collections.Generic;
using MarcaModelo.Data;

namespace MarcaModelo.AppServices
{
    public interface IMarcaCrudService
    {
        IEnumerable<Marca> GetMarcas();
        Marca GetById(int IDMarca);
        void Desactivar(int IDMarca);
        void Activar(int IDMarca);
        IEnumerable<IInvalidValueInfo> Persist(Marca marca);
        //void Persist(Marca marca);
        IEnumerable<Marca> GetMarcasInactivas();
        
    }
}
