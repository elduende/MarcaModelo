using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;
using MarcaModelo.TestDataBuilders;

namespace MarcaModelo.Data.Tests
{
    [TestClass]
    public class MarcaTest
    {
        [TestMethod]
        public void CtrProtection()
        {
            //ActionAssert.NotThrow(() => new Marca());
            Executing.This(() => new Marca());
        }

        [TestMethod]
        public void WhenChangeDescripcionAsignItToProperty()
        {
            var marca = MarcaBuilder.Default();
            marca.Descripcion = "Descripcion 2";
            marca.Descripcion.Should().Be("Descripcion 2");
        }

        [TestMethod]
        public void WhenChangeEstadoAsignItToProperty()
        {
            var marca = MarcaBuilder.Default();
            marca.Estado = "B";
            marca.Estado.Should().Be("B");
        }

        [TestMethod]
        public void WhenSameDescripcionAreEquals()
        {
            var oldMarca = new Marca { Descripcion = "Descripcion 1" };
            var newMarca = new Marca { Descripcion = "Descripcion 1" };
            oldMarca.Should().Be(newMarca);
        }

        [TestMethod]
        public void WhenAnotherObjetAreNotEquals()
        {
            (MarcaBuilder.Default())
                .Should().Not.Be(new object());
        }

        [TestMethod]
        public void WhenDiferentDescripcionAreNotEquals()
        {
            var newMarca = new Marca { Descripcion = "Descripcion 2" };
            MarcaBuilder.Default()
                .Should().Not.Be(newMarca);
        }

        [TestMethod]
        public void WhenSameDescripcionSameHashCode()
        {
            var oldMarca = new Marca { Descripcion = "Descripcion 1" };
            var newMarca = new Marca { Descripcion = "Descripcion 1" };
            oldMarca.GetHashCode().Should().Be(newMarca.GetHashCode());
        }

        [TestMethod]
        public void WhenDiferentDescripcionDiferentHashCode()
        {
            MarcaBuilder.Default().GetHashCode()
                .Should().Not.Be(new Marca { Descripcion = "Descripcion 2" }.GetHashCode());
        }

        [TestMethod]
        public void MayAddModeloImmediately()
        {
            var marca = MarcaBuilder.DefaultPersistent();
            //ActionAssert.NotThrow(() => marca.AddModelo(ModeloBuilder.DefaultPersistent()));
            Executing.This(() => marca.AddModelo(ModeloBuilder.DefaultPersistent()));
        }

        //[TestMethod]
        //public void AddModeloAreAggregates()
        //{
        //var marca = MarcaBuilder.DefaultPersistent();
        //marca.AddModelo(ModeloBuilder.DefaultPersistent());
        //marca.Modelos.Count().Should().Be(1);
        //marca.AddModelo(ModeloBuilder.StartRec().
        //    With(m => m.Descripcion = "Descripcion 1").
        //    With(m => m.Estado = "A").
        //    Build());
        //marca.Modelos.Count().Should().Be(2);
        //}

        //[TestMethod]
        //public void ModelosNotAdmitDuplicates()
        //{
        //    var marca = MarcaBuilder.DefaultPersistent();
        //    marca.AddModelo(ModeloBuilder.Default());
        //    marca.AddModelo(ModeloBuilder.Default());
        //    marca.Modelos.Count().Should().Be(1);
        //}

        [TestMethod]
        public void DeleteInstanceModeloDeleteIt()
        {
            var marca = MarcaBuilder.Default();
            var modelo = ModeloBuilder.Default();
            
            modelo.Marca = marca;
            marca.AddModelo(modelo);
            marca.RemoveModelo(modelo);
            marca.Modelos.Should().Be.Empty();
        }

        [TestMethod]
        public void ChangeDescripcionToNullMayCalculateTheHash()
        {
            var marca = MarcaBuilder.Default();
            marca.Descripcion = null;
            //ActionAssert.NotThrow(() => branch.GetHashCode());
            Executing.This(() => marca.GetHashCode());
        }
    }
}
