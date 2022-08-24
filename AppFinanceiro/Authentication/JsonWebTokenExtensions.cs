using System.Security.Claims;

namespace Financ.Api.Security
{
    public static class JsonWebTokenExtensions
    {
        public static void AddJti(this List<Claim> claims)
        {
            claims.Add(new Claim(JwtClaims.Jti, Guid.NewGuid().ToString("N")));
        }

        public static void AddUserId(this List<Claim> claims, Guid id)
        {
            claims.Add(new Claim(JwtClaims.UserId, id.ToString()));
        }

        public static void AddName(this List<Claim> claims, string name)
        {
            claims.Add(new Claim(JwtClaims.UserName, name));
        }

        public static void AddEmail(this List<Claim> claims, string email)
        {
            claims.Add(new Claim(JwtClaims.UserEmail, email));
        }

        public static void AddRoles(this List<Claim> claims, IEnumerable<string> roles)
        {
            if (roles != null && roles.Any())
                claims.AddRange(roles.Select(z => new Claim(ClaimTypes.Role,z)));
        }
    }
}
