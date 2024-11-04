using Bogus;
using CookBook.Communication.Requests;

namespace CommonTestUtilities.requests
{
    public class RequestRegisterUserJsonBuilder
    {
        public static RequestRegisterUserJson Build(int passwordLength = 10)
        {
            return new Faker<RequestRegisterUserJson>()
                .RuleFor(user => user.name, (f) => f.Person.FullName)
                .RuleFor(user => user.email, (f, user) => f.Internet.Email(user.name))
                .RuleFor(user => user.password, (f) => f.Internet.Password(passwordLength));
        }
    }
}
