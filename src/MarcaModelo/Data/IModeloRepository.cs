namespace MarcaModelo.Data
{
    public interface IModeloRepository
    {
        Marca Marca { get; set; }
        int IDModelo { get; set; }
        string Descripcion { get; set; }
        string Estado { get; set; }
        Modelo GetById(int IDModelo);
        void Persist(Modelo modelo);
    }
}
