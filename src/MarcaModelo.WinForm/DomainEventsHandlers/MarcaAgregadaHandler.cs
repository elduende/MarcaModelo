using System;
using MarcaModelo.Events;
using MarcaModelo.Sistema.Events;

namespace MarcaModelo.WinForm.DomainEventsHandlers
{
    /// <summary>
	/// Esto es solo un ejemplo para entender como funcionan los eventos de dominio
	/// </summary>
	public class MarcaAgregadaHandler: IDomainEventHandler<MarcaAgregadaEvent>
    {
        public void Handle(MarcaAgregadaEvent args)
        {
            Console.WriteLine("Fue emitido un remito");
        }
    }
}
