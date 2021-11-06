using MediatR;

namespace ContactService.Application.Mediator.Commands
{
    public class AddContactRequestCommand : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MailAddress { get; set; }
        public string Message { get; set; }

        public AddContactRequestCommand(string firstName, string lastName, string mailAddress, string message)
        {
            FirstName = firstName;
            LastName = lastName;
            MailAddress = mailAddress;
            Message = message;
        }
    }
}
