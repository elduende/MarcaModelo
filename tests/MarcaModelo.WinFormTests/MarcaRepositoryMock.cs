﻿using System;
using System.Collections.Generic;
using System.Linq;
using MarcaModelo.Data;
using MarcaModelo.WinFormTests.MarcaViewModelTests;

namespace MarcaModelo.WinFormTests
{
    public class MarcaRepositoryMock : IMarcaRepository
    {
        private readonly List<Modelo> modelos;

        public int? IDMarca { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        public IList<Modelo> Modelos
        {
            get { return modelos.ToList(); }
        }

        int? IMarcaRepository.IDMarca
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

        string IMarcaRepository.Descripcion
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

        string IMarcaRepository.Estado
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

        public void AddModelo(Modelo modelo)
        {
            if (modelo == null)
            {
                return;
            }
            modelos.Add(modelo);
        }

        //IList<Modelo> IMarcaRepository.Modelos()
        //{
        //    return modelos;
        //}

        public Marca GetById(int IDMarca)
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

        public void Inactivate(int IDMarca)
        {
            throw new NotImplementedException();
        }

        public void Activate(int IDMarca)
        {
            throw new NotImplementedException();
        }

        public void Activate(int? IDMarca)
        {
            throw new NotImplementedException();
        }

        public void Inactivate(int? iDMarca)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Modelo> IMarcaRepository.Modelos()
        {
            throw new NotImplementedException();
        }

        Marca IMarcaRepository.GetById(int IDMarca)
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

        void IMarcaRepository.AddModelo(Modelo modelo)
        {
            throw new NotImplementedException();
        }

        void IMarcaRepository.Activate(int? IDMarca)
        {
            throw new NotImplementedException();
        }

        void IMarcaRepository.Inactivate(int? iDMarca)
        {
            throw new NotImplementedException();
        }
    }
}
