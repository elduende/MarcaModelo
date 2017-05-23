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

        public Marca Marca
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
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
    }
}
