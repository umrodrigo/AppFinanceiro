using Financ.Api.Models;
using Microsoft.Extensions.Options;

namespace Financ.Api.Services.Cryptography
{
    public interface ICryptoManager
    {
        string EncryptSHA256(string value);
        string EncryptMD5(string value);
        string EncryptPasswordLogin(string value);
        
    }
}
