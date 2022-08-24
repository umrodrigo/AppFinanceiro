using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Financ.Api.Security
{
    public class AuthSchemas
    {
        public const string Passport = "Passport";
        public const string Bearer = JwtBearerDefaults.AuthenticationScheme;
    }

    public static class JwtClaims
    {
        public const string Jti = JwtRegisteredClaimNames.Jti;
        public const string UserId = ClaimTypes.NameIdentifier;
        public const string UserName = ClaimTypes.Name;
        public const string UserEmail = ClaimTypes.Email;
    }
}
