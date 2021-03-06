﻿namespace MarcaModelo.Entities
{
    public class Modelo : BaseEntity
    {
        public Modelo()
        {

        }

        public virtual Marca Marca { get; set; }
        public virtual int IDModelo { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string Estado { get; set; }


        public virtual bool Equals(Modelo that)
        {
            if (base.Equals(that))
            {
                return true;
            }
            if (ReferenceEquals(null, that)) return false;
            return Equals(that.Marca, Marca) && Equals(that.Descripcion, Descripcion);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Modelo);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Marca != null ? Marca.GetHashCode() : 0);
                result = (result * 397) ^ (Descripcion != null ? Descripcion.GetHashCode() : 0);
                return result;
            }
        }
    }
}
