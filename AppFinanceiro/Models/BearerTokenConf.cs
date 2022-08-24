namespace Financ.Api.Models
{
    public class BearerTokenConf
    {
        public string Issuer { get; set; }
        public string Audiences { get; set; }
        public string Key { get; set; }
    }
}
