using System.Linq;
using Kolo.Core.Services;
using Kolo.Service.Services;
using Ninject;
using NUnit.Framework;

namespace Kolo.Service.Tests
{
    [TestFixture]
    class Dependency_Injection_Tests
    {
        [Test]
        public void Ninject_Test()
        {
            var kernel = NinjectCommon.CreateKernel();

            var appAssembly = typeof(NinjectCommon).Assembly;

            var controllerTypes =
                from type in appAssembly.GetExportedTypes()
                where typeof(DnsQueryHandler).IsAssignableFrom(type)
                where !type.IsAbstract
                where !type.IsGenericTypeDefinition
                select type;

            foreach (var controllerType in controllerTypes)
                kernel.Get(controllerType);
        }
    }
}
