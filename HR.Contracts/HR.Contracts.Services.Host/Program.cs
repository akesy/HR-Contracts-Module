using System;
using System.ServiceModel;
using Autofac;
using Autofac.Integration.Wcf;
using HR.Contracts.Services.Abstract;
using HR.Contracts.Services.Concrete;

namespace HR.Contracts.Services.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoMapperConfig.RegisterMappings();

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(AppDomain.CurrentDomain.GetAssemblies());

            using (var container = builder.Build())
            {
                using (var host = new ServiceHost(typeof(ContractService)))
                {
                    var binding = new BasicHttpBinding();
                    host.AddServiceEndpoint(typeof(IContractService), binding, string.Empty);
                    host.AddServiceEndpoint(typeof(ISalaryService), binding, string.Empty);
                    host.AddDependencyInjectionBehavior<ContractService>(container);

                    host.Open();

                    Console.WriteLine("Host started @ " + DateTime.Now);
                    Console.ReadLine();
                }
            }
        }
    }
}