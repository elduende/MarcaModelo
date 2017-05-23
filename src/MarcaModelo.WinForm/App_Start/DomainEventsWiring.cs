using MarcaModelo.Services;
using MarcaModelo.Sistema.Events;

namespace MarcaModelo.WinForm
{
    public class DomainEventsWiring
    {
        private static DomainEventHandlersStore store;

        public static void RegisterHandlers(IServiceContainer container)
        {
            store = new DomainEventHandlersStore();
            RegisterAllEvents(container);
            DomainEvents.Initialize(store);
        }

        private static void RegisterAllEvents(IServiceContainer container)
        {
            // Descomentar la linea de abajo para activar el evento
            //store.RegisterHandlerOf(()=> new MarcaAgregadaHandler());
        }
    }
}
