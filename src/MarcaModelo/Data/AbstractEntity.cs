namespace MarcaModelo.Data
{
    public abstract class AbstractEntity<TIdentity> : IEntity<TIdentity>
    {
        protected int? RequestedHashCode;

        #region IEntity Members

        public abstract TIdentity Id { get; protected set; }

        /// <summary>
        /// Compare equality through ID
        /// </summary>
        /// <param name="other">Entity to compare.</param>
        /// <returns>true if are equals</returns>
        /// <remarks>
        /// Two entities are equals if they are of the same hierarchy tree/sub-tree
        /// and has same id.
        /// </remarks>
        public virtual bool Equals(IEntity<TIdentity> other)
        {
            if (null == other || (!GetType().IsInstanceOfType(other) && !other.GetType().IsInstanceOfType(this)))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            bool otherIsTransient = Equals(other.Id, default(TIdentity));
            bool thisIsTransient = IsTransient();
            if (otherIsTransient && thisIsTransient)
            {
                return ReferenceEquals(other, this);
            }

            return other.Id.Equals(Id);
        }

        #endregion

        protected bool IsTransient()
        {
            return Equals(Id, default(TIdentity));
        }

        public override bool Equals(object obj)
        {
            var that = obj as IEntity<TIdentity>;
            return Equals(that);
        }

        public override int GetHashCode()
        {
            if (!RequestedHashCode.HasValue)
            {
                RequestedHashCode = IsTransient() ? base.GetHashCode() : Id.GetHashCode();
            }
            return RequestedHashCode.Value;
        }

    }
}
