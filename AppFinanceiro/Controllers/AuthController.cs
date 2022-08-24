using Financ.Api.ViewModel.Interface;
using Financ.Api.View.Models;
using Microsoft.AspNetCore.Mvc;
using Financ.Api.Services.Log;
using Microsoft.AspNetCore.Authorization;
using Financ.Api.Security;

namespace Financ.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AuthController : ControllerBase
    {
        protected readonly IAuthentication _authentication;
        public AuthController(IAuthentication auth)
        {
            _authentication = auth;
        }

        [HttpPost]
        public async Task<Authenticated> Login([FromBody] AuthModel auth)
        {
            try
            {
                if (auth == null)
                    throw new Exception("Login não informado");

                

                return await _authentication.Authenticate(auth);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}