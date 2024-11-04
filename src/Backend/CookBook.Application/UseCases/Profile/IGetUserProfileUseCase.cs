using CookBook.Communication.Responses;

namespace CookBook.Application.UseCases.Profile
{
    public interface IGetUserProfileUseCase
    {
        public Task<ResponseUserProfileJson> Execute();
    }
}
