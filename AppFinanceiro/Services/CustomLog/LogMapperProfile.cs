using AutoMapper;
using Financ.Api.View.Models;

namespace Financ.API.Services.Log
{
    public class LogMapper
    {
        public IMapper Mapper { get; private set; }
        public LogMapper(IMapper mapper)
        {
            Mapper = mapper;
        }
    }

    public class LogMapperProfile : Profile
    {
        public LogMapperProfile()
        {
            CreateMap<UserView, ActionLog>()
                .ForMember(dest => dest.UserLog, opt =>
                {
                    opt.MapFrom((src) => new UserLog
                    {
                        IdUser = src.Id.ToString(),
                        Name = src.Name,
                        Email = src.Email,
                        Phone = src.Phone
                    });
                });
            
        }
    }
}
