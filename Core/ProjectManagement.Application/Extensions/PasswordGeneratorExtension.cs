using Microsoft.Extensions.Configuration;
using NETCore.Encrypt.Extensions;

namespace ProjectManagement.Application.Extensions
{
    public class PasswordGeneratorExtension
    {
        public static string PasswordHashGenerate(IConfiguration configuration,string password)
        {
            string salt = configuration.GetValue<string>("Password:Salt");
            string salted = $"{password}{salt}";
            string hashed = salted.MD5();
            return hashed;

        }
    }
}
