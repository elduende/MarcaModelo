using System.Collections.Generic;
using Iesi.Collections.Generic;

namespace MarcaModelo.Entities
{
    public class Marca : BaseEntity
    {
        private Iesi.Collections.Generic.ISet<Modelo> _modelos;
        public Marca()
        {
            _modelos = new HashedSet<Modelo>();
        }

        public virtual int IdMarca { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string Estado { get; set; }
        public virtual IEnumerable<Modelo> Modelos => _modelos;

        public virtual void AddModelo(Modelo modelo)
        {
            if (modelo.Marca != null && !Equals(modelo.Marca, this))
            {
                modelo.Marca.RemoveModelo(modelo);
            }

            modelo.Marca = this;
            _modelos.Add(modelo);
        }

        public virtual void RemoveModelo(Modelo modelo)
        {
            if (modelo.Marca != null && Equals(modelo.Marca, this))
            {
                _modelos.Remove(modelo);
                modelo.Marca = null;
            }
        }

        public virtual bool Equals(Marca that)
        {
            if (base.Equals(that))
            {
                return true;
            }
            if (ReferenceEquals(null, that)) return false;
            return Equals(that.Descripcion, Descripcion);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Marca);
        }

        public override int GetHashCode()
        {
            var result = (Descripcion != null ? Descripcion.GetHashCode() : 0);
            return result;
        }
    }
}
