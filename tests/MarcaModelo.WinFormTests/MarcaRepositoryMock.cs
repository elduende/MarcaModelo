using System;
using System.Collections.Generic;
using System.Linq;
using MarcaModelo.Data;
using MarcaModelo.WinFormTests.MarcaViewModelTests;

namespace MarcaModelo.WinFormTests
{
    public class MarcaRepositoryMock : IMarcaRepository
    {
        Marca _marca = new Marca();
        //private readonly List<Modelo> modelos;
        private Iesi.Collections.Generic.ISet<Modelo> _modelos;

        int IMarcaRepository.IdMarca { get; set; }
        string IMarcaRepository.Descripcion { get; set; }
        string IMarcaRepository.Estado { get; set; }

        //public IEnumerable<Modelo> Modelos
        //{
        //    get { return modelos.ToList(); }
        //}

        IEnumerable<Modelo> IMarcaRepository.Modelos()
        {
            //get { return modelos.ToList(); }
            return _modelos.ToList();
        }

        //public int IDMarca { get; set; }
        //public string Descripcion { get; set; }
        //public string Estado { get; set; }

        //public void AddModelo(Modelo modelo)
        //{
        //    if (modelo == null)
        //    {
        //        return;
        //    }
        //    modelos.Add(modelo);
        //}

        void IMarcaRepository.AddModelo(Modelo modelo)
        {
            _marca.AddModelo(modelo);
        }

        public void RemoveModelo(Modelo modelo)
        {
            _marca.RemoveModelo(modelo);
        }

        //IList<Modelo> IMarcaRepository.Modelos()
        //{
        //    return modelos;
        //}

        public static IMarcaRepository Empty()
        {
            return new MarcaRepositoryMock();
        }
        
        public Marca GetById(int idMarca)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Marca> GetMarcas()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Marca> GetMarcasInactivas()
        {
            throw new NotImplementedException();
        }

        public void Persist(Marca marca)
        {
            throw new NotImplementedException();
        }

        public void Inactivate(int idMarca)
        {
            throw new NotImplementedException();
        }

        public void Activate(int idMarca)
        {
            throw new NotImplementedException();
        }

        Marca IMarcaRepository.GetById(int idMarca)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Marca> IMarcaRepository.GetMarcas()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Marca> IMarcaRepository.GetMarcasInactivas()
        {
            throw new NotImplementedException();
        }

        void IMarcaRepository.Persist(Marca marca)
        {
            throw new NotImplementedException();
        }

        void IMarcaRepository.Activate(int idMarca)
        {
            throw new NotImplementedException();
        }

        void IMarcaRepository.Inactivate(int iDMarca)
        {
            throw new NotImplementedException();
        }
    }
}
