using System.Collections.Generic;
using System.Linq;
using MarcaModelo.Data;
using MarcaModelo.WinForm.Common;
using MarcaModelo.WinForm.Models;
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
            ModeloRepository = new Modelo((Marca)MarcaRepository) { IDModelo = 1, Descripcion = "2050 PLUS", Estado = "A" };
            ModeloRepository.IDModelo.Should().Be(1);
        }

        [TestMethod]
        public void AfterCreationModeloThenDescripcionAvailable()
        {
            IMarcaRepository MarcaRepository = new MarcaRepositoryMock();
            MarcaRepository = new Marca { IDMarca = 19, Descripcion = "Epson", Estado = "A" };

            IModeloRepository ModeloRepository = new ModeloRepositoryMock();
            ModeloRepository = new Modelo((Marca)MarcaRepository) { IDModelo = 1, Descripcion = "2050 PLUS", Estado = "A" };
            ModeloRepository.Descripcion.Should().Be("2050 PLUS");
        }

        [TestMethod]
        public void AfterCreationModeloThenEstadoAvailable()
        {
            IMarcaRepository MarcaRepository = new MarcaRepositoryMock();
            MarcaRepository = new Marca { IDMarca = 19, Descripcion = "Epson", Estado = "A" };

            IModeloRepository ModeloRepository = new ModeloRepositoryMock();
            ModeloRepository = new Modelo((Marca)MarcaRepository) { IDModelo = 1, Descripcion = "2050 PLUS", Estado = "A" };
            ModeloRepository.Estado.Should().Be("A");
        }

        [TestMethod]
        public void AfterCreationModeloThenMarcaAvailable()
        {
            IMarcaRepository MarcaRepository = new MarcaRepositoryMock();
            MarcaRepository = new Marca { IDMarca = 19, Descripcion = "2050 PLUS", Estado = "A" };

            IModeloRepository ModeloRepository = new ModeloRepositoryMock();
            ModeloRepository = new Modelo((Marca)MarcaRepository) { IDModelo = 1, Descripcion = "2050 PLUS", Estado = "A" };
            ModeloRepository.Marca.IDMarca.Should().Be(19);
        }
    }
}
