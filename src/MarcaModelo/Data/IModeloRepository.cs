namespace MarcaModelo.Data
{
    public interface IModeloRepository
    {
        Marca Marca { get; set; }
        int IdModelo { get; set; }
        string Descripcion { get; set; }
        string Estado { get; set; }
        Modelo GetById(int idModelo);
        void Persist(Modelo modelo);
    }
}
