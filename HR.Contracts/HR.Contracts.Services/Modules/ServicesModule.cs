using Autofac;
using HR.Contracts.Services.Abstract;
using HR.Contracts.Services.Concrete;

namespace HR.Contracts.Services.Modules
{
    class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<ContractService>();
        }
    }
}