using HR.Contracts.Services.Concrete;
using System;
using System.ServiceModel;

namespace HR.Contracts.Services.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoMapperConfig.RegisterMappings();

            using (var host = new ServiceHost(typeof(ContractService)))
            {
                host.Open();
                Console.WriteLine("Host started @ " + DateTime.Now);
                Console.ReadLine();
            }
        }
    }
}
