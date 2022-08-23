using AutoMapper;
using Financ.Api.ViewModel.Interface;
using Financ.Data;
using Financ.Data.Clients;
using Financ.Data.Models;
using Financ.Api.View.Models;

namespace Financ.Api.ViewModel
{
    public class UserViewModel : BaseViewModel, IUserViewModel
    {
        public IMapper Mapper => _mapper;
        public FinancContext Context => _context;
        private readonly UserRep _Rep;
        public UserViewModel(FinancContext context, IMapper mapper) 
            : base(context, mapper)
        {
            _Rep = new UserRep(_context);
        }

        public async Task<List<UserView>> GetAll()
        {
            var result = await _Rep.GetAll();
            return _mapper.Map<List<UserView>>(result);
        }

        public async Task<List<UserView>> Get(int pageIndex, int pageSize, string search)
        {
            var result = await _Rep.Get(pageIndex, pageSize, search);
            return _mapper.Map<List<UserView>>(result);
        }
        public async Task<UserView> GetById(Guid id)
        {
            var result = await _Rep.GetById(id);
            return _mapper.Map<UserView>(result);
        }

        public async Task Insert(UserView view)
        {
            var model = _Rep.Save(_mapper.Map<User>(view));

            await _context.SaveChangesAsync();
            _mapper.Map(model, view);
        }
        public async Task Update(UserView view)
        {
            var model = _Rep.Save(_mapper.Map<User>(view));

            await _context.SaveChangesAsync();
            _mapper.Map(model, view);
        }
    }
}
