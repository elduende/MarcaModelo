using MarcaModelo.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace MarcaModelo.Tests
{
    [TestClass]
    public class SimpleServiceProviderTests
    {
        public interface IMyService { }

        public class MyService : IMyService { }

        [TestMethod]
        public void WhenNoServiceRegisteredThenNull()
        {
            var factory = new SimpleServiceContainer();
            var actual = factory.GetInstance<IMyService>();
            actual.Should().Be.Null();
        }

        [TestMethod]
        public void WhenServiceRegisteredThenGetInstance()
        {
            var factory = new SimpleServiceContainer();
            factory.RegisterTransient<IMyService>(x => new MyService());
            var actual = factory.GetInstance<IMyService>();
            actual.Should().Be.OfType<MyService>();
        }

        [TestMethod]
        public void WhenTransientServiceThenGetNewInstance()
        {
            var factory = new SimpleServiceContainer();
            factory.RegisterTransient<IMyService>(x => new MyService());

            var first = factory.GetInstance<IMyService>();
            var actual = factory.GetInstance<IMyService>();
            actual.Should().Not.Be.SameInstanceAs(first);
        }

        [TestMethod]
        public void WhenServiceRegisteredAsSingletonThenGetSameInstance()
        {
            var factory = new SimpleServiceContainer();
            factory.RegisterSingleton<IMyService>(x => new MyService());

            var first = factory.GetInstance<IMyService>();
            var actual = factory.GetInstance<IMyService>();
            actual.Should().Be.SameInstanceAs(first);
        }

        [TestMethod]
        public void WhenInstanceRegisteredAsSingletonThenGetSameInstance()
        {
            var factory = new SimpleServiceContainer();
            var myInstance = new MyService();
            factory.RegisterSingleton<IMyService>(myInstance);

            var actual = factory.GetInstance<IMyService>();
            actual.Should().Be.SameInstanceAs(myInstance);
        }
    }
}
