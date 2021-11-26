using System;
using System.Threading;
using System.Threading.Tasks;
using ContactService.Application.Mediator.Commands;
using ContactService.Services;
using MediatR;

namespace ContactService.Application.Mediator.Handler
{
    public class AddContactRequestCommandHandler : IRequestHandler<AddContactRequestCommand, bool>
    {
        private readonly IContactService _contactService;

        public AddContactRequestCommandHandler(IContactService contactService)
        {
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
        }

        public async Task<bool> Handle(AddContactRequestCommand request, CancellationToken cancellationToken) => await _contactService.SaveContactForm(request);
    }
}
