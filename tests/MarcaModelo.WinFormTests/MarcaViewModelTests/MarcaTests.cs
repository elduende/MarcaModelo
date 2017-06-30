using System.Linq;
using MarcaModelo.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace MarcaModelo.WinFormTests.MarcaViewModelTests
{
    [TestClass]
    public class MarcaTests
    {
        [TestMethod]
        public void AfterCreationMarcaThenIdMarcaAvailable()
        {
            IMarcaRepository marcaRepository = new MarcaRepositoryMock();
            marcaRepository = new Marca { IdMarca = 19, Descripcion = "Epson", Estado = "A" };
            marcaRepository.IdMarca.Should().Be(19);
        }

        [TestMethod]
        public void AfterCreationMarcaThenDescripcionAvailable()
        {
            IMarcaRepository marcaRepository = new MarcaRepositoryMock();
            marcaRepository = new Marca { IdMarca = 19, Descripcion = "Epson", Estado = "A" };
            marcaRepository.Descripcion.Should().Be("Epson");
        }

        [TestMethod]
        public void AfterCreationMarcaThenEstadoAvailable()
        {
            IMarcaRepository marcaRepository = new MarcaRepositoryMock();
            marcaRepository = new Marca { IdMarca = 19, Descripcion = "Epson", Estado = "A" };
            marcaRepository.Estado.Should().Be("A");
        }

        [TestMethod]
        public void AfterCreationMarcaAddModeloThenListModeloAvailable()
        {
            IMarcaRepository marcaRepository = new MarcaRepositoryMock();
            marcaRepository = new Marca { IdMarca = 19, Descripcion = "Epson", Estado = "A" };

            IModeloRepository modeloRepository = new ModeloRepositoryMock();
            modeloRepository = new Modelo((Marca)marcaRepository) { IdModelo = 1, Descripcion = "Genérico", Estado = "A" };

            marcaRepository.AddModelo((Modelo)modeloRepository);
            marcaRepository.Modelos().Select(x => x.Descripcion).Should().Contain("Genérico");
        }
    }
}
