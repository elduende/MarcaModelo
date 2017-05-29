using System;

namespace MarcaModelo.Entities
{
    public interface IEntity<TIdentity> : IEquatable<IEntity<TIdentity>>
    {
        TIdentity Id { get; }
    }
}
