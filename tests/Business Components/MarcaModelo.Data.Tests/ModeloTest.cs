using SharpTestsEx;
using MarcaModelo.TestDataBuilders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MarcaModelo.Data.Tests
{
    [TestClass]
    public class ModeloTest
    {
        [TestMethod]
        public void CtrProtection()
        {
            //ActionAssert.NotThrow(() => new Modelo());
            Executing.This(() => new Modelo());
        }

        [TestMethod]
        public void WhenChangeDescripcionAsignItToProperty()
        {
            var modelo = ModeloBuilder.Default();
            modelo.Descripcion = "Descripcion 2";
            modelo.Descripcion.Should().Be("Descripcion 2");
        }

        [TestMethod]
        public void WhenChangeEstadoAsignItToProperty()
        {
            var modelo = ModeloBuilder.Default();
            modelo.Estado = "B";
            modelo.Estado.Should().Be("B");
        }

        [TestMethod]
        public void WhenSameDescripcionAreEquals()
        {
            var oldModelo = new Modelo { Descripcion = "Descripcion 1" };
            var newModelo = new Modelo { Descripcion = "Descripcion 1" };
            oldModelo.Should().Be(newModelo);
        }

        [TestMethod]
        public void WhenAnotherMarcaAreNotEquals()
        {
            var oldMarca = MarcaBuilder.Default();
            var newMarca = MarcaBuilder.Default();
            newMarca.Descripcion = "Descripcion 2";
            var oldModelo = new Modelo { Descripcion = "Descripcion 1", Marca = oldMarca };
            var newModelo = new Modelo { Descripcion = "Descripcion 1", Marca = newMarca };
            oldModelo.Should().Not.Be(newModelo);
        }

        [TestMethod]
        public void WhenAnotherObjetAreNotEquals()
        {
            (ModeloBuilder.Default())
                .Should().Not.Be(new object());
        }

        [TestMethod]
        public void WhenDiferentDescripcionAreNotEquals()
        {
            var newModelo = new Modelo { Descripcion = "Descripcion 2" };
            ModeloBuilder.Default()
                .Should().Not.Be(newModelo);
        }

        [TestMethod]
        public void WhenSameDescripcionSameHashCode()
        {
            var oldModelo = new Modelo { Descripcion = "Descripcion 1" };
            var newModelo = new Modelo { Descripcion = "Descripcion 1" };
            oldModelo.GetHashCode().Should().Be(newModelo.GetHashCode());
        }

        [TestMethod]
        public void WhenDiferentDescripcionDiferentHashCode()
        {
            ModeloBuilder.Default().GetHashCode()
                .Should().Not.Be(new Modelo { Descripcion = "Descripcion 2" }.GetHashCode());
        }
    }
}
