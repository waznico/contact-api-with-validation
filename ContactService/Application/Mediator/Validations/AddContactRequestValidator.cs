using System;
using ContactService.Application.Mediator.Commands;
using FluentValidation;

namespace ContactService.Application.Mediator.Validations
{
    public class AddContactRequestValidator : AbstractValidator<AddContactRequestCommand>
    {
        public AddContactRequestValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().Matches(RegexValidationStrings.Name).WithMessage("FirstName can at maximum conain 50 characters, whitespaces and special chars (.-)");
            RuleFor(c => c.LastName).NotEmpty().Matches(RegexValidationStrings.Name).WithMessage("LastName can at maximum conain 50 characters, whitespaces and special chars (.-)");
            RuleFor(c => c.MailAddress).NotEmpty().EmailAddress().WithMessage("Mail address must be a valid email address and can not be empty");
            RuleFor(c => c.Message).NotEmpty().Matches(RegexValidationStrings.Message).WithMessage("Message can be between 1 and 500 characters long and must not contain <>%$\\[]#';");
        }
    }
}
