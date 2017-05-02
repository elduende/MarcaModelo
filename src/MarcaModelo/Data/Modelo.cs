using System;
using System.Collections.Generic;

namespace MarcaModelo.Data
{
    public class Modelo: IModeloRepository
    {
        private Marca marca { get; set; }
        public Modelo(Marca _marca)
        {
            marca = _marca;
            marca.IDMarca = _marca.IDMarca;
        }
        public int IDModelo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        Marca IModeloRepository.Marca
        {
            get
            {
                //throw new NotImplementedException();
                return marca;
            }

            set
            {
                //throw new NotImplementedException();
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

        public IEnumerable<Modelo> GetModelos(int IDMarca)
        {
            throw new NotImplementedException();
        }

        public void Persist(Modelo modelo)
        {
            throw new NotImplementedException();
        }
    }
}
