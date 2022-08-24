using Financ.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Financ.Api.Security
{
    public class JsonWebToken : IJsonWebToken
    {
        protected readonly BearerSigning _bearerSigning;
        protected readonly PassportSigning _passportSigning;

        public JsonWebToken(BearerSigning bearerSigning, PassportSigning passportSigning)
        {
            _bearerSigning = bearerSigning;
            _passportSigning = passportSigning;
        }

        public (string, DateTime) Generate(Guid idUser, string name, string email, IEnumerable<string> roles)
        {
            var sec = new JwtSecurityToken
                (
                    _bearerSigning.TokenValidation.ValidIssuer,
                    _bearerSigning.TokenValidation.ValidAudience,
                    SetClaims(idUser, name, email, roles),
                    DateTime.Now,
                    DateTime.UtcNow.AddDays(1),
                    _bearerSigning.SigningCredentials
                );
            string tk = new JwtSecurityTokenHandler().WriteToken(sec);

            return (tk, sec.ValidTo);
        }

        public string GeneratePassport(Guid idUser, string audience, IEnumerable<string> roles)
        {
            var tks = new JwtSecurityToken
                (
                    issuer: _passportSigning.TokenValidation.ValidIssuer,
                    audience: audience,
                    claims: SetClaims(idUser, audience, null, roles),
                    signingCredentials: _passportSigning.SigningCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(tks);
        }

        private List<Claim> SetClaims(Guid idUser, string name, string email, IEnumerable<string> roles)
        {
            var claims = new List<Claim>();
            claims.AddJti();
            claims.AddUserId(idUser);
            claims.AddName(name);
            claims.AddEmail(email);
            claims.AddRoles(roles);

            return claims;
        }
    }
}
