using System;

namespace MarcaModelo.Data
{
    public interface IEntity<TIdentity> : IEquatable<IEntity<TIdentity>>
    {
        TIdentity Id { get; }
    }
}
