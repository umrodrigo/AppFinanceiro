using Financ.Api.Models;
using Microsoft.Extensions.Options;

namespace Financ.Api.Services.Cryptography
{
    public class CryptoManager : ICryptoManager
    {
        private readonly CriptoManagerConf _criptoManagerConf;

        public CryptoManager(IOptions<CriptoManagerConf> option)
        {
            _criptoManagerConf = option.Value;
        }

        public string EncryptSHA256(string value)
        {
            return Tools.Cryptography.Sha256(value);
        }

        public string EncryptMD5(string value)
        {
            return Tools.Cryptography.EncryptMD5(value);
        }

        public string EncryptPasswordLogin(string value)
        {
            return Tools.Cryptography.EncryptMD5(value);
        }
    }
}
