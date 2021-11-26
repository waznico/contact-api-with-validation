using System.Threading.Tasks;
using ContactService.Application.Mediator.Commands;

namespace ContactService.Services
{
    public interface IContactService
    {
        Task<bool> SaveContactForm(AddContactRequestCommand request);
    }
}
