using System;
using System.Threading;
using System.Threading.Tasks;
using ContactService.Application.Mediator.Commands;
using MediatR;

namespace ContactService.Application.Mediator.Handler
{
    public class AddContactRequestCommandHandler : IRequestHandler<AddContactRequestCommand, bool>
    {
        public async Task<bool> Handle(AddContactRequestCommand request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            return true;
        }
    }
}
