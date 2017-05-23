namespace MarcaModelo.Data
{
    public class BaseEntity : AbstractEntity<int>
    {
        #region Overrides of AbstractEntity

        public override int Id { get; protected set; }

        #endregion
    }
}
