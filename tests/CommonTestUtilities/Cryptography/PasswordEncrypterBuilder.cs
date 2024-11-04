using CookBook.Domain.Security.Criptography;
using CookBook.Infrastructure.Security.Criptography;

namespace CommonTestUtilities.Cryptography
{
    public class PasswordEncrypterBuilder
    {
        public static IPasswordEncrypter Build() => new Sha512Encrypter("ery");
    }
}
