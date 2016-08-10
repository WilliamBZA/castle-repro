using NHibernate;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class TestService : IService
    {
        public TestService(ISession session)
        {

        }

        static ILog log = LogManager.GetLogger<TestService>();

        public void SomeMethod()
        {
        }
    }

    public interface IService
    {
        void SomeMethod();
    }
}
