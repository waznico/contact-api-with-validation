using System.Reflection;
using Autofac;
using ContactService.Application.Mediator.Commands;
using ContactService.Application.Mediator.Handler;
using ContactService.Application.Mediator.Pipelines;
using ContactService.Application.Mediator.Validations;
using FluentValidation;
using MediatR;

namespace ContactService.Infrastructure.AutofacModules
{
    public class MediatorModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            // Register all the Command classes (they implement IRequestHandler) in assembly holding the Commands
            builder.RegisterAssemblyTypes(typeof(AddContactRequestCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            // Register the Command's Validators (Validators based on FluentValidation library)
            builder
                .RegisterAssemblyTypes(typeof(AddContactRequestValidator).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();

            builder
            .RegisterAssemblyTypes(typeof(AddContactRequestValidator).GetTypeInfo().Assembly)
            .Where(t => t.IsClosedTypeOf(typeof(AbstractValidator<>)));

            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });

            builder.RegisterGeneric(typeof(ValidationPipelineBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
