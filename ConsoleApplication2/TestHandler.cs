using NHibernate;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class TestHandler : IHandleMessages<Test>
    {
        private IService service;
        private ISession session;

        public TestHandler(ISession nhSession, IService myService)
        {
            service = myService;
            session = nhSession;
        }

        public void Handle(Test message)
        {
            Console.WriteLine("Message recieved");
        }
    }
}
