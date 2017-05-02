using System;
using System.Security.Principal;
using MarcaModelo.Sistema.Events;
using MarcaModelo.Data;

namespace MarcaModelo.Events
{
    public class MarcaAgregadaEvent: IDomainEvent
    {
        public MarcaAgregadaEvent(Marca marca, IPrincipal emisor)
        {
            if (marca == null)
            {
                throw new ArgumentNullException("marca");
            }
            Marca = marca;
            Emisor = emisor;
        }

        public Marca Marca { get; private set; }
        public IPrincipal Emisor { get; private set; }
    }
}
