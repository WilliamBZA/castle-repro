using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NServiceBus;
using NServiceBus.Persistence.NHibernate;
using NServiceBus.Configuration.AdvanceExtensibility;
using NServiceBus.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var busConfiguration = new BusConfiguration();

            var persistence = busConfiguration.UsePersistence<NHibernatePersistence>().ConnectionString(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NServiceBus;Integrated Security=True;");
            persistence.RegisterManagedSessionInTheContainer();

            var container = new WindsorContainer();
            var registration = Component.For<IService>().ImplementedBy<TestService>();

            container.Register(registration);
            var sadsad = busConfiguration.GetSettings();
            busConfiguration.UseContainer<WindsorBuilder>(
                customizations: customizations =>
                {
                    customizations.ExistingContainer(container);
                });

            //var kernel = new StandardKernel();
            //kernel.Bind<IService>().To<TestService>();

            //busConfiguration.UseContainer<NinjectBuilder>(
            //    customizations: customizations =>
            //    {
            //        customizations.ExistingKernel(kernel);
            //    });

            busConfiguration.EndpointName("Register.Test");
            busConfiguration.EnableInstallers();

            using (var bus = Bus.Create(busConfiguration).Start())
            {
                bus.SendLocal(new Test());
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }
    }
}