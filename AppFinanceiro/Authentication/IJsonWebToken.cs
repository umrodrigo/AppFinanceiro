namespace Financ.Api.Security
{
    public interface IJsonWebToken
    {
        (string, DateTime) Generate(Guid idUser, string name, string email, IEnumerable<string> roles);
        string GeneratePassport(Guid idUser, string audience, IEnumerable<string> roles);
    }
}
