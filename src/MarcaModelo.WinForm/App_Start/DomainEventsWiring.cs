using MarcaModelo.Services;
using MarcaModelo.Sistema.Events;

namespace MarcaModelo.WinForm
{
    public class DomainEventsWiring
    {
        private static DomainEventHandlersStore _store;

        public static void RegisterHandlers(IServiceContainer container)
        {
            _store = new DomainEventHandlersStore();
            RegisterAllEvents(container);
            DomainEvents.Initialize(_store);
        }

        private static void RegisterAllEvents(IServiceContainer container)
        {
            // Descomentar la linea de abajo para activar el evento
            //store.RegisterHandlerOf(()=> new MarcaAgregadaHandler());
        }
    }
}
