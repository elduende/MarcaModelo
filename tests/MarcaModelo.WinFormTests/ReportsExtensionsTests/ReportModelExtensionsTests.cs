using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MarcaModelo.WinForm.Common;
using Microsoft.Reporting.WinForms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace MarcaModelo.WinFormTests.ReportsExtensionsTests
{
    [TestClass]
    public class ReportModelExtensionsTests
    {
        [TestMethod]
        public void WhenNullModelThenEmptyCollection()
        {
            object model = null;
            IEnumerable<ReportParameter> actual = model.ToReportParameters();
            actual.Should().Be.Empty();
        }

        [TestMethod]
        public void WhenModelHasOneProperyThenParameterWithOneElement()
        {
            object model = new { Nombre = 123 };
            var actual = model.ToReportParameters();
            actual.Should().Have.Count.EqualTo(1);
        }

        [TestMethod]
        public void WhenModelHasOneProperyThenParameterWithNameOfProperty()
        {
            object model = new { Nombre = 123 };
            var actual = model.ToReportParameters();
            actual.First().Name.Should().Be("Nombre");
        }

        [TestMethod]
        public void WhenProperyIntegerThenParameterWithValueString()
        {
            object model = new { Nombre = 123 };
            var actual = model.ToReportParameters();
            actual.First().Values[0].Should().Be("123");
        }

        [TestMethod]
        public void WhenProperyDateTimeThenParameterWithValueString()
        {
            var dateTime = DateTime.Now;
            object model = new { Nacimiento = dateTime };
            var actual = model.ToReportParameters();
            actual.First().Values[0].Should().Be(dateTime.ToString("s"));
        }

        [TestMethod]
        public void WhenProperyDecimaThenParameterWithValueString()
        {
            var importe = 134.456M;
            object model = new { Importe = importe };
            var actual = model.ToReportParameters();
            actual.First().Values[0].Should().Be(importe.ToString("G", CultureInfo.InvariantCulture));
        }

        [TestMethod]
        public void WhenProperyStringThenParameterWithValueString()
        {
            object model = new { Nombre = "Ermenegildo" };
            var actual = model.ToReportParameters();
            actual.First().Values[0].Should().Be("Ermenegildo");
        }

        [TestMethod]
        public void WhenProperyEnumerableOfIntegersThenParameterWithValuesString()
        {
            var numeros = new[] { 1, 2, 3 }.AsEnumerable();
            object model = new { Numeros = numeros };
            var actual = model.ToReportParameters();
            actual.First().Values.Cast<string>().Should().Have.SameSequenceAs("1", "2", "3");
        }

        [TestMethod]
        public void WhenProperyEnumerableOfStringThenParameterWithValuesString()
        {
            var nombres = new[] { "Ermenegildo", "Osvaldo" }.AsEnumerable();
            object model = new { Nombre = nombres };
            var actual = model.ToReportParameters();
            actual.First().Values.Cast<string>().Should().Have.SameSequenceAs("Ermenegildo", "Osvaldo");
        }

        [TestMethod]
        public void WhenProperyEnumerableOfStringWithNullThenParameterWithValuesStringAndNull()
        {
            var nombres = new[] { "Ermenegildo", null }.AsEnumerable();
            object model = new { Nombre = nombres };
            var actual = model.ToReportParameters();
            actual.First().Values.Cast<string>().Should().Have.SameSequenceAs("Ermenegildo", null);
        }

        [TestMethod]
        public void WhenProperyEnumerableOfDateTimeThenParameterWithValuesString()
        {
            var dateTime1 = DateTime.Now;
            var dateTime2 = DateTime.Now.AddDays(1);
            object model = new { Nacimiento = new[] { dateTime1, dateTime2 } };
            var actual = model.ToReportParameters();
            actual.First().Values.Cast<string>().Should().Have.SameSequenceAs(dateTime1.ToString("s"), dateTime2.ToString("s"));
        }

        public void EjemploDeUso()
        {
            var foo = new { UenId = 1234, ZonaId = new[] { 1, 2, 3 }, CobradorNombre = "Eduardo", Inicio = DateTime.Today.AddDays(-15), Fin = DateTime.Today };
            //var vm = new ReportViewModel(Reportes.DetalleComisionCobrador, foo);
        }
    }

    public class Reportes
    {
        /// <summary>
        /// Reporte fulano de tal (summary para que aparezca en el tootip mientras programamos)
        /// </summary>
        public static string DetalleComisionCobrador = "PathDelReportEnReportingService";
    }
}
