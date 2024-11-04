using CookBook.Communication.Requests;
using CookBook.Communication.Responses;
using CookBook.Domain.Repositories.User;
using CookBook.Domain.Security.Criptography;
using CookBook.Domain.Security.Tokens;
using CookBook.Exceptions.ExeptionsBase;

namespace CookBook.Application.UseCases.Login.DoLogin
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        private readonly IUserReadOnlyRepository _repository;
        private readonly IPasswordEncrypter _passwordEncryter;
        private readonly IAccessTokenGenerator _accessTokenGenerator;

        public DoLoginUseCase(IUserReadOnlyRepository repository, IPasswordEncrypter passwordEncryter, IAccessTokenGenerator accessTokenGenerator)
        {
            _repository = repository;
            _passwordEncryter = passwordEncryter;
            _accessTokenGenerator = accessTokenGenerator;
        }

        public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
        {
            var encriptedPassword = _passwordEncryter.Encrypt(request.Password);

            var user = await _repository.GetByEmailAndPassword(request.Email, encriptedPassword) ?? throw new InvalidLoginException();

            return new ResponseRegisteredUserJson { Name = user.Name,
                Tokens = new ResponseTokensJson
                {
                    AccessToken = _accessTokenGenerator.Generate(user.UserIdentifier),
                }
            };
        }
    }
}
