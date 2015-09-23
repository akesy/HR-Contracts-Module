using System.Data.Entity;
using Autofac;
using HR.Contracts.Domain.Abstract;
using HR.Contracts.Domain.Concrete;

namespace HR.Contracts.Domain.Modules
{
    class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<DefaultSalaryCalculator>().As<ISalaryCalculator>();
            builder.RegisterType<DefaultSalaryPolicy>().As<ISalaryPolicy>();
            builder.RegisterType<EFDbContext>().As<DbContext>();
            builder.RegisterGeneric(typeof(EFRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();            
        }
    }
}