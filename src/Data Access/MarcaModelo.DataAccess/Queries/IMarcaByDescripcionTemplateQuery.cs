using MarcaModelo.Entities;

namespace MarcaModelo.DataAccess.Queries
{
    public interface IMarcaByDescripcionTemplateQuery
    {
        string DescripcionTemplate { get; set; }
        IPagedResults<Marca> GetResults(int pageSize, int pageNumber);
    }
}
