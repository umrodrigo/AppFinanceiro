using AutoMapper;
using Financ.Data.Models;
using Financ.View.Models;

namespace Financ.API.Tools
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserView, User>();
        }
    }
}
