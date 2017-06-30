using System;
using System.Collections.Generic;
using MarcaModelo.Data;

namespace MarcaModelo.WinFormTests
{
    public class ModeloRepositoryMock : IModeloRepository
    {
        public int IdMarca { get; set; }
        public int IdModelo { get; set; }
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

        public IEnumerable<object> Componentes()
        {
            throw new NotImplementedException();
        }

        Modelo IModeloRepository.GetById(int idModelo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Modelo> GetModelos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Modelo> GetModelos(int pPagina, int pTamanoPagina, string pBuscar)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Modelo> GetModelosInactivos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Modelo> GetModelosInactivos(int pPagina, int pTamanoPagina, string pBuscar)
        {
            throw new NotImplementedException();
        }

        public int GetModelosCantidad(int pIdMarca)
        {
            throw new NotImplementedException();
        }

        public int GetModelosInactivosCantidad(int pIdMarca)
        {
            throw new NotImplementedException();
        }

        public void AddComponente(object pComponente)
        {
            throw new NotImplementedException();
        }

        public void RemoveComponente(object pComponente)
        {
            throw new NotImplementedException();
        }

        public void Activate(int pIdModelo)
        {
            throw new NotImplementedException();
        }

        public void Inactivate(int pIdModelo)
        {
            throw new NotImplementedException();
        }
    }
}
