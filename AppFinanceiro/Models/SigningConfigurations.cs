using Microsoft.IdentityModel.Tokens;

namespace Financ.Api.Models
{
    public class BearerSigning
    {
        public SecurityKey IssuerSigningKey { get; }
        public SigningCredentials SigningCredentials { get; }
        public TokenValidationParameters TokenValidation { get; }

        public BearerSigning(string key, string issuer, string audience)
        {
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key));
            SigningCredentials = new SigningCredentials(IssuerSigningKey, SecurityAlgorithms.HmacSha256Signature);

            TokenValidation = new TokenValidationParameters
            {
                ValidateActor = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidIssuer = issuer,
                ValidAudience = audience,
                RequireSignedTokens = true,
                IssuerSigningKey = IssuerSigningKey
            };
        }
    }

    public class PassportSigning
    {
        public SecurityKey IssuerSigningKey { get; }
        public SigningCredentials SigningCredentials { get; }
        public TokenValidationParameters TokenValidation { get; }

        public PassportSigning(string key, string issuer, string[] audience)
        {
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key));
            SigningCredentials = new SigningCredentials(IssuerSigningKey, SecurityAlgorithms.HmacSha256Signature);

            TokenValidation = new TokenValidationParameters
            {
                ValidateActor = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidIssuer = issuer, //quem gerou token
                ValidAudiences = audience, //quem pode usar token
                RequireSignedTokens = true,
                IssuerSigningKey = IssuerSigningKey
            };
        }
    }

}
