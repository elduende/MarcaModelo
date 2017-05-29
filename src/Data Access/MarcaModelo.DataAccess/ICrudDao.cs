namespace MarcaModelo.DataAccess
{
    /// <summary>
	/// Generic Data Access Object contract for a read-write entity.
	/// </summary>
	/// <typeparam name="TEntity">Entity's type.</typeparam>
	public interface ICrudDao<TEntity>
    {
        TEntity MakePersistent(TEntity entity);
        void MakeTransient(TEntity entity);
    }
}
