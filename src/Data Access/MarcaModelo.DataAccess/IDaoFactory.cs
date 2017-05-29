namespace MarcaModelo.DataAccess
{
    /// <summary>
	/// Provides an interface for retrieving DAO objects
	/// </summary>
	public interface IDaoFactory
    {
        T GetDao<T>() where T : class;
        TQuery GetQuery<TQuery>() where TQuery : class;
    }
}
