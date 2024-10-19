using System.Security.Cryptography;
using System.Text;

namespace CookBook.Application.Services.Cryptography
{
    public class PasswordEncryter
    {

        private readonly string _additionalKey;

        public PasswordEncryter(string additionalKey) => _additionalKey = additionalKey;

        public string Encrypt(string password)
        {
            var additionalKey = "Ery";
            var newPassword = $"{password}{additionalKey}"; 

            var bytes = Encoding.UTF8.GetBytes(newPassword);
            var hashBytes = SHA512.HashData(bytes);

            return StringBytes(hashBytes);
        }

        private static string StringBytes(byte[] bytes) 
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
    }
}
