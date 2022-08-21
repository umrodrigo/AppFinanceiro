using AutoMapper;
using Financ.API.ViewModel.Interface;
using Financ.Data;
using Financ.Data.Clients;
using Financ.View.Models;

namespace Financ.API.ViewModel
{
    public class UserViewModel : BaseViewModel, IUserViewModel
    {
        public IMapper Mapper => _mapper;
        public FinancContext Context => _context;
        private readonly UserRep _rep;
        public UserViewModel(FinancContext context, IMapper mapper) 
            : base(context, mapper)
        {
            _rep = new UserRep(_context);
        }
        //public async Task<List<UserView>> GetAll()
        //{
        //    var result = await _rep.
        //}
    }
}
