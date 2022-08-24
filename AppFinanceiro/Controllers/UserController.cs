using Financ.Api.ViewModel.Interface;
using Financ.Api.View.Models;
using Microsoft.AspNetCore.Mvc;
using Financ.Api.Services.Log;
using Microsoft.AspNetCore.Authorization;
using Financ.Api.Security;

namespace Financ.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(Policy = AuthSchemas.Bearer, Roles = "users")]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class UserController : ControllerBase
    {
        protected readonly IUserViewModel _vm;
        protected readonly ILog _logService;
        public UserController(IUserViewModel vm, ILog log)
        {
            _vm = vm;
            _logService = log;
        }

        [HttpGet("getAll")]
        public async Task<List<UserView>> GetAll()
        {
            try
            {
                var result = await _vm.GetAll();

                _logService
                    .Build(true)
                    .Complements("Requisição de todos os Usuários")
                    .Add();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("get")]
        public async Task<List<UserView>> Get(int pageIndex = 0, int pageSize = 10, string search = "")
        {
            try
            {
                return await _vm.Get(pageIndex, pageSize, search);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("getById")]
        public async Task<UserView> GetById(Guid id)
        {
            try
            {
                return await _vm.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("post")]
        public async Task<UserView> Post([FromBody] UserView view)
        {
            try
            {
                await _vm.Insert(view);
                return view;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("put")]
        public async Task<UserView> Put([FromBody] UserView view)
        {
            try
            {
                await _vm.Update(view);
                return view;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}