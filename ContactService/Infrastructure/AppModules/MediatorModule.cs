using System.Reflection;
using Autofac;
using ContactService.Application.Mediator.Handler;
using FluentValidation;
using MediatR;

namespace ContactService.Infrastructure.AppModules
{
    public class MediatorModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            // Register all the Command classes(they implement IRequestHandler) in assembly holding the Commands
            builder.RegisterAssemblyTypes(typeof(AddContactRequestCommandHandler)
                    .GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Validator"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("PipelineBehavior"))
                .AsClosedTypesOf(typeof(IPipelineBehavior<,>))
                .InstancePerLifetimeScope();

        }
    }
}
