using CookBook.Communication.Requests;
using CookBook.Communication.Responses;

namespace CookBook.Application.UseCases.Login.DoLogin
{
    public interface IDoLoginUseCase
    {
        public Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request);
    }
}
