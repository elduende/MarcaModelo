namespace MarcaModelo.DataAccess
{
    public interface IEntityDao<T> : IDao<T, int>, ICrudDao<T> where T : class
    {
    }
}
