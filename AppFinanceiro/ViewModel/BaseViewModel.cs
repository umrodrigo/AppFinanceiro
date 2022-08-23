using AutoMapper;
using Financ.Data;

namespace Financ.Api.ViewModel
{
    public class BaseViewModel
    {
        protected FinancContext _context;
        protected IMapper _mapper;
        public BaseViewModel(FinancContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
    }
}
