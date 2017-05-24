using System;
using System.Collections.Generic;

namespace MarcaModelo.Data
{
    public class Modelo : BaseEntity, IModeloRepository
    {
        private Marca marca { get; set; }

        //[CMS] - Le tuve que sacar el constructor que recibe Marca como parámetro
        //public Modelo(Marca _marca)
        //{
        //    marca = _marca;
        //    marca.IDMarca = _marca.IDMarca;
        //}
        public Modelo()
        {
            
        }

        public int IDModelo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public virtual Marca Marca { get; set; }

        Marca IModeloRepository.Marca
        {
            get
            {
                return marca;
            }

            set
            {
                marca = marca;
            }
        }

        public Modelo GetById(int IDModelo)
        {
            throw new NotImplementedException();
        }

        public void Persist(Modelo modelo)
        {
            throw new NotImplementedException();
        }

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
                int result = (Descripcion != null ? Descripcion.GetHashCode() : 0);
                return result;
            }
        }
    }
}
