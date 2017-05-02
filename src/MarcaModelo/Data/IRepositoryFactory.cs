namespace MarcaModelo.Data
{
    public interface IRepositoryFactory
    {
        TRepository GetRepository<TRepository>() where TRepository : class;
    }
}
