using System;
using MarcaModelo.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace MarcaModelo.Tests.GenericRepositoryFactoryTests
{
    public class RegistrationTransientTests
    {
        public interface IMyRepo { }

        public class MyRepo : IMyRepo { }

        [TestMethod]
        public void WhenNoRepoRegisteredThenThrow()
        {
            var factory = new GenericRepositoryFactory();
            factory.Executing(x => x.GetRepository<IMyRepo>()).Throws<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void WhenRepoRegisteredThenGetInstance()
        {
            var factory = new GenericRepositoryFactory();
            factory.RegisterTransient<IMyRepo>(x => new MyRepo());
            var actual = factory.GetRepository<IMyRepo>();
            actual.Should().Be.OfType<MyRepo>();
        }

        [TestMethod]
        public void WhenRepoRegisteredAsSingletonThenGetSameInstance()
        {
            var factory = new GenericRepositoryFactory();
            factory.RegisterSingleton<IMyRepo>(x => new MyRepo());

            var first = factory.GetRepository<IMyRepo>();
            var actual = factory.GetRepository<IMyRepo>();
            actual.Should().Be.SameInstanceAs(first);
        }
    }
}
