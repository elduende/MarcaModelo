﻿using MarcaModelo.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace MarcaModelo.WinFormTests.ModeloViewModelTests
{
    [TestClass]
    public class ModeloTests
    {
        [TestMethod]
        public void AfterCreationModeloThenIDModeloAvailable()
        {
            IMarcaRepository MarcaRepository = new MarcaRepositoryMock();
            MarcaRepository = new Marca { IDMarca = 19, Descripcion = "Epson", Estado = "A" };

            IModeloRepository ModeloRepository = new ModeloRepositoryMock();
            ModeloRepository = new Modelo() { IDModelo = 1, Descripcion = "2050 PLUS", Estado = "A" };
            ModeloRepository.IDModelo.Should().Be(1);
        }

        [TestMethod]
        public void AfterCreationModeloThenDescripcionAvailable()
        {
            IMarcaRepository MarcaRepository = new MarcaRepositoryMock();
            MarcaRepository = new Marca { IDMarca = 19, Descripcion = "Epson", Estado = "A" };

            IModeloRepository ModeloRepository = new ModeloRepositoryMock();
            ModeloRepository = new Modelo() { IDModelo = 1, Descripcion = "2050 PLUS", Estado = "A" };
            ModeloRepository.Descripcion.Should().Be("2050 PLUS");
        }

        [TestMethod]
        public void AfterCreationModeloThenEstadoAvailable()
        {
            IMarcaRepository MarcaRepository = new MarcaRepositoryMock();
            MarcaRepository = new Marca { IDMarca = 19, Descripcion = "Epson", Estado = "A" };

            IModeloRepository ModeloRepository = new ModeloRepositoryMock();
            ModeloRepository = new Modelo() { IDModelo = 1, Descripcion = "2050 PLUS", Estado = "A" };
            ModeloRepository.Estado.Should().Be("A");
        }

        //[CMS] - Tuve que sacar el test cuando saqué Marca como parámetro de entrada del constructor de Modelo
        //[TestMethod]
        //public void AfterCreationModeloThenMarcaAvailable()
        //{
        //    IMarcaRepository MarcaRepository = new MarcaRepositoryMock();
        //    MarcaRepository = new Marca { IDMarca = 19, Descripcion = "2050 PLUS", Estado = "A" };

        //    IModeloRepository ModeloRepository = new ModeloRepositoryMock();
        //    ModeloRepository = new Modelo() { IDModelo = 1, Descripcion = "2050 PLUS", Estado = "A" };
        //    ModeloRepository.Marca.IDMarca.Should().Be(19);
        //}
    }
}
