using System.Collections.Generic;

namespace MarcaModelo.Data
{
    public interface IMarcaRepository
    {
        //ISet<Modelo> modelos = new HashSet<Modelo>();
        IList<Modelo> Modelos();
        int? IDMarca { get; set; }
        string Descripcion { get; set; }
        string Estado { get; set; }
        Marca GetById(int IDMarca);
        IEnumerable<Marca> GetMarcas();
        IEnumerable<Marca> GetMarcasInactivas();
        void Persist(Marca marca);
        void AddModelo(Modelo modelo);
        void Activate(int? IDMarca);
        void Inactivate(int? iDMarca);
    }
}
