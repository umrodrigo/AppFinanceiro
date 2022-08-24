using Financ.Api.Services.Cryptography;
using Financ.Api.Services.Log;
using Financ.Data;
using Financ.Data.Clients;
using Financ.Data.Models;

namespace Financ.Api.Security
{
    public class Authentication : IAuthentication
    {
        protected readonly FinancContext _context;
        private readonly UserRep _userRep;
        private readonly ILog _logService;
        private readonly IJsonWebToken _jsonWebToken;
        private readonly ICryptoManager _cryptoManager;

        public Authentication(FinancContext context, ILog logService, IJsonWebToken jsonWebToken, ICryptoManager cryptoManager)
        {
            _context = context;
            _userRep = new UserRep(context);
            _logService = logService;
            _jsonWebToken = jsonWebToken;
            _cryptoManager = cryptoManager;
        }

        public async Task<Authenticated> Authenticate(AuthModel auth)
        {
            try
            {
                User user = null;
                Validate(auth);

                auth.Password = _cryptoManager.EncryptPasswordLogin(auth.Password);

                var userExist = await _userRep.Authenticate(auth.UserName, auth.Password);

                if (userExist == null)
                    throw new Exception("Usuário ou senha inválidos");

                user = await _userRep.GetUserByAuth(userExist);

                var authenticated = new Authenticated
                {
                    Id = user.Id,
                    Name = user.Name,
                };
                GetJwt(ref authenticated, user.Id, user.Name, user.Email);

                _logService.Build(true)
                    .User(user)
                    .Add();

                return authenticated;
            }
            catch (Exception ex)
            {
                _logService.Build(false)
                    .Complements("Tentativa de Login, User: " + auth.UserName)
                    .Add();

                throw;
            }
        }

        private void GetJwt(ref Authenticated authenticated, Guid idUser, string name, string email)
        {
            (string tk, DateTime valid) = _jsonWebToken.Generate(idUser, name, email, GetClaims(idUser));
            authenticated.Token = tk;
            authenticated.Expiration = valid;
        }

        private IEnumerable<string> GetClaims(Guid idUser)
        {
            return _userRep.GetRoles(idUser).Result;
        }

        private void Validate(AuthModel auth)
        {
            if (string.IsNullOrEmpty(auth.UserName) || string.IsNullOrWhiteSpace(auth.UserName))
                throw new Exception("Preencha o E-mail corretamente");
            if (string.IsNullOrEmpty(auth.Password) || string.IsNullOrWhiteSpace(auth.Password))
                throw new Exception("Preencha a Senha corretamente");
            if (auth.UserName.Length < 6)
                throw new Exception("User deve ter pelo menos 6 catacteres");
            if (auth.Password.Length < 6)
                throw new Exception("A senha deve ter pelo menos 6 caracteres");
        }
    }
}
