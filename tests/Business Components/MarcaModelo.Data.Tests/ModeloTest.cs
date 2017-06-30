﻿using SharpTestsEx;
using MarcaModelo.TestDataBuilders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MarcaModelo.Data.Tests
{
    [TestClass]
    public class ModeloTest
    {
        [TestMethod]
        public void ModeloCtrProtection()
        {
            //ActionAssert.NotThrow(() => new Modelo());
            Executing.This(() => new Modelo(MarcaBuilder.Default()));
        }

        [TestMethod]
        public void ModeloWhenChangeDescripcionAsignItToProperty()
        {
            var modelo = ModeloBuilder.Default();
            modelo.Descripcion = "Descripcion 2";
            modelo.Descripcion.Should().Be("Descripcion 2");
        }

        [TestMethod]
        public void ModeloWhenChangeEstadoAsignItToProperty()
        {
            var modelo = ModeloBuilder.Default();
            modelo.Estado = "B";
            modelo.Estado.Should().Be("B");
        }

        [TestMethod]
        public void ModeloWhenSameDescripcionAreEquals()
        {
            var oldModelo = new Modelo(MarcaBuilder.Default()) { Descripcion = "Descripcion 1" };
            var newModelo = new Modelo(MarcaBuilder.Default()) { Descripcion = "Descripcion 1" };
            oldModelo.Should().Be(newModelo);
        }

        [TestMethod]
        public void ModeloWhenAnotherMarcaAreNotEquals()
        {
            var oldMarca = MarcaBuilder.Default();
            var newMarca = MarcaBuilder.Default();
            newMarca.Descripcion = "Descripcion 2";
            var oldModelo = new Modelo(oldMarca) { Descripcion = "Descripcion 1", IdMarca = oldMarca.IdMarca };
            var newModelo = new Modelo(newMarca) { Descripcion = "Descripcion 1", IdMarca = newMarca.IdMarca };
            oldModelo.Should().Not.Be(newModelo);
        }

        [TestMethod]
        public void ModeloWhenAnotherObjetAreNotEquals()
        {
            (ModeloBuilder.Default())
                .Should().Not.Be(new object());
        }

        [TestMethod]
        public void ModeloWhenDiferentDescripcionAreNotEquals()
        {
            var newModelo = new Modelo(MarcaBuilder.Default()) { Descripcion = "Descripcion 2" };
            ModeloBuilder.Default()
                .Should().Not.Be(newModelo);
        }

        [TestMethod]
        public void ModeloWhenSameDescripcionSameHashCode()
        {
            var oldModelo = new Modelo(new Marca()) { Descripcion = "Descripcion 1" };
            var newModelo = new Modelo(new Marca()) { Descripcion = "Descripcion 1" };
            oldModelo.GetHashCode().Should().Be(newModelo.GetHashCode());
        }

        [TestMethod]
        public void ModeloWhenDiferentDescripcionDiferentHashCode()
        {
            ModeloBuilder.Default().GetHashCode()
                .Should().Not.Be(new Modelo(MarcaBuilder.Default()) { Descripcion = "Descripcion 2" }.GetHashCode());
        }
    }
}
