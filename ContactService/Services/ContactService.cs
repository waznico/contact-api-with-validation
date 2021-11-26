using System;
using System.Threading.Tasks;
using ContactService.Application.Mediator.Commands;
using ContactService.Infrastructure.Database;
using ContactService.Models.Database;

namespace ContactService.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactContext _context;

        public ContactService(ContactContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> SaveContactForm(AddContactRequestCommand request)
        {
            var contactEntity = new ContactForm()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MailAddress = request.MailAddress,
                Message = request.Message
            };

            _context.Add(contactEntity);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
    }
}
