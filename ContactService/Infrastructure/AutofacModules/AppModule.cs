using Autofac;
using ContactService.Services;

namespace ContactService.Infrastructure.AutofacModules
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Services.ContactService>()
                .As<IContactService>().InstancePerLifetimeScope();
        }
    }
}
