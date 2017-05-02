using System.Collections.Generic;

namespace MarcaModelo.Sistema.Events
{
    public interface IDomainEventHandlersStore
    {
        /// <summary>
        ///   Get all registered events handlers.
        /// </summary>
        /// <typeparam name="T">The type of event.</typeparam>
        /// <returns>Instances of IDomainEventHandler{T} or an empty enumerable.</returns>
        IEnumerable<IDomainEventHandler<T>> GetHandlersOf<T>() where T : IDomainEvent;
    }
}
