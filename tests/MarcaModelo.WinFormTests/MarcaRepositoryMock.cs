using System;
using System.Collections.Generic;
using System.Linq;
using MarcaModelo.Data;
using MarcaModelo.WinFormTests.MarcaViewModelTests;

namespace MarcaModelo.WinFormTests
{
    public class MarcaRepositoryMock : IMarcaRepository
    {
        private readonly List<Modelo> modelos;

        public int IDMarca { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        public IList<Modelo> Modelos
        {
            get { return modelos.ToList(); }
        }
        public void Add(Modelo modelo)
        {
            if (modelo == null)
            {
                return;
            }
            modelos.Add(modelo);
        }

        IList<Modelo> IMarcaRepository.Modelos()
        {
            return modelos;
        }

        public Marca GetById(int IDMarca)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Marca> GetMarcas()
        {
            throw new NotImplementedException();
        }

        public void Persist(Marca marca)
        {
            throw new NotImplementedException();
        }
    }
}
