using System;
using System.Collections.Generic;
using System.Linq;
using MarcaModelo.Data;
//using MarcaModelo.WinFormTests.MarcaViewModelTests;

namespace MarcaModelo.WinFormTests
{
    public class ModeloRepositoryMock : IModeloRepository
    {
        public int IDModelo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        
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

        Modelo IModeloRepository.GetById(int IDModelo)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Modelo> IModeloRepository.GetModelos(int IDMarca)
        {
            throw new NotImplementedException();
        }

        void IModeloRepository.Persist(Modelo modelo)
        {
            throw new NotImplementedException();
        }
    }
}
