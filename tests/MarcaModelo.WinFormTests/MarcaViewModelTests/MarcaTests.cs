using System.Collections.Generic;
using System.Linq;
using MarcaModelo.Data;
using MarcaModelo.WinForm.Common;
using MarcaModelo.WinForm.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace MarcaModelo.WinFormTests.MarcaViewModelTests
{
    [TestClass]
    public class MarcaTests
    {
        [TestMethod]
        public void AfterCreationMarcaThenIDMarcaAvailable()
        {
            IMarcaRepository MarcaRepository = new MarcaRepositoryMock();
            MarcaRepository = new Data.Marca { IDMarca = 19, Descripcion = "Epson", Estado = "A" };
            MarcaRepository.IDMarca.Should().Be(19);
        }

        [TestMethod]
        public void AfterCreationMarcaThenDescripcionAvailable()
        {
            IMarcaRepository MarcaRepository = new MarcaRepositoryMock();
            MarcaRepository = new Data.Marca { IDMarca = 19, Descripcion = "Epson", Estado = "A" };
            MarcaRepository.Descripcion.Should().Be("Epson");
        }

        [TestMethod]
        public void AfterCreationMarcaThenEstadoAvailable()
        {
            IMarcaRepository MarcaRepository = new MarcaRepositoryMock();
            MarcaRepository = new Data.Marca { IDMarca = 19, Descripcion = "Epson", Estado = "A" };
            MarcaRepository.Estado.Should().Be("A");
        }

        [TestMethod]
        public void AfterCreationMarcaAddModeloThenListModeloAvailable()
        {
            IMarcaRepository MarcaRepository = new MarcaRepositoryMock();
            MarcaRepository = new Data.Marca { IDMarca = 19, Descripcion = "Epson", Estado = "A" };

            IModeloRepository ModeloRepository = new ModeloRepositoryMock();
            //ModeloRepository = new Modelo((Data.Marca)MarcaRepository) { IDModelo = 1, Descripcion = "Genérico", Estado = "A" };
            ModeloRepository = new Modelo() { IDModelo = 1, Descripcion = "Genérico", Estado = "A" };

            MarcaRepository.AddModelo((Modelo)ModeloRepository);
            MarcaRepository.Modelos().Select(x => x.Descripcion).Should().Contain("Genérico");
        }
    }
}
