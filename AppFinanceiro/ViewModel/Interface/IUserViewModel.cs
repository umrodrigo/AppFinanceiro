using AutoMapper;
using Financ.Data;
using Financ.Api.View.Models;

namespace Financ.Api.ViewModel.Interface
{
    public interface IUserViewModel
    {
        IMapper Mapper { get; }
        FinancContext Context { get; }
        Task<List<UserView>> GetAll();
        Task<List<UserView>> Get(int pageIndex = 0, int pageSize = 10, string search = "");
        Task<UserView> GetById(Guid id);
        Task Insert(UserView view);
        Task Update(UserView view);
    }
}
