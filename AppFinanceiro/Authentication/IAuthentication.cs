namespace Financ.Api.Security
{
    public interface IAuthentication
    {
        Task<Authenticated> Authenticate(AuthModel auth);
    }
}
