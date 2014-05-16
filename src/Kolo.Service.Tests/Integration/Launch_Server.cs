using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Kolo.Service.Tests.Integration
{
    [TestFixture]
    class Launch_Server
    {
        [Test]
        public void Launch()
        {
            Kolo.Service.Program.Main(new string[0]);
        }
    }
}
