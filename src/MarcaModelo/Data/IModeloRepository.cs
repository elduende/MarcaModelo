using System.Collections.Generic;

namespace MarcaModelo.Data
{
    public interface IModeloRepository
    {
        Marca Marca { get; set; }
        int IDModelo { get; set; }
        string Descripcion { get; set; }
        string Estado { get; set; }
        Modelo GetById(int IDModelo);
        IEnumerable<Modelo> GetModelos(int IDMarca);
        void Persist(Modelo modelo);
    }
}
