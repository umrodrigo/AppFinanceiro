using Financ.Api.ViewModel.Interface;
using Financ.Api.View.Models;
using Microsoft.AspNetCore.Mvc;

namespace Financ.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        protected readonly IUserViewModel _vm;
        public UserController(IUserViewModel vm)
        {
            _vm = vm;
        }

        [HttpGet("getAll")]
        public async Task<List<UserView>> GetAll()
        {
            try
            {
                return await _vm.GetAll();
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