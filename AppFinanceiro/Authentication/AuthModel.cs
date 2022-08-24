namespace Financ.Api.Security
{
    public class AuthModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class ResetPasswordView
    {
        public string Id { get; set; }
        public string OldPass { get; set; }
        public string NewPass { get; set; }
        public string NewPassConfirm { get; set; }
    }

    public class Authenticated
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
