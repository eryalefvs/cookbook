using CookBook.Communication.Requests;
using CookBook.Domain.Repositories;
using CookBook.Domain.Repositories.User;
using CookBook.Domain.Security.Criptography;
using CookBook.Domain.Services.LoggedUser;
using CookBook.Exceptions;
using CookBook.Exceptions.ExeptionsBase;

namespace CookBook.Application.UseCases.User.ChangePassword
{
    public class ChangePasswordUseCase : IChangePasswordUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IUserUpdateOnlyRepository _repository;
        private readonly IPasswordEncrypter _passwordEncrypter;
        private readonly IUnitOfWork _unitOfWork;

        public ChangePasswordUseCase(
        ILoggedUser loggedUser,
        IPasswordEncrypter passwordEncrypter,
        IUserUpdateOnlyRepository repository,
            IUnitOfWork unitOfWork)
        {
            _loggedUser = loggedUser;
            _passwordEncrypter = passwordEncrypter;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(RequestChangePasswordJson request)
        {
            var loggedUser = await _loggedUser.User();

            Validate(request, loggedUser);

            var user = await _repository.GetById(loggedUser.Id);

            user.Password = _passwordEncrypter.Encrypt(request.NewPassword);

            _repository.Update(user);

            await _unitOfWork.Commit();
        }

        private void Validate(RequestChangePasswordJson request, Domain.Entities.User loggedUser)
        {
            var result = new ChangePasswordValidator().Validate(request);

            var currentPassworEncrypted = _passwordEncrypter.Encrypt(request.Password);

            if (!currentPassworEncrypted.Equals(loggedUser.Password))
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceMessagesException.PASSWORD_DIFFERENT_CURRENT_PASSWORD));

            if (!result.IsValid)
                throw new ErrorOnValidationException(result.Errors.Select(e => e.ErrorMessage).ToList());
        }
    }
}
