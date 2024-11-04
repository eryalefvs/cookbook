using CookBook.Application.SharedValidators;
using CookBook.Communication.Requests;
using CookBook.Exceptions;
using FluentValidation;

namespace CookBook.Application.UseCases.User.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(user => user.name).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);
            RuleFor(user => user.email).NotEmpty().WithMessage(ResourceMessagesException.EMAIL_EMPTY);
            RuleFor(user => user.password).SetValidator(new PasswordValidator<RequestRegisterUserJson>());
            When(user => string.IsNullOrEmpty(user.email) == false, () =>
            {
                RuleFor(user => user.email).EmailAddress().WithMessage(ResourceMessagesException.EMAIL_INVALID);
            });
        }
    }
}
