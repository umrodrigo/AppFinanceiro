namespace Financ.API.Services.Log
{
    public class LogService : ILog
    {
        private readonly LogMapper _mapper;
        private readonly ILogRepository _repo;
        private ActionLog Log;

        public LogService(LogMapper mapper, ILogRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        private ActionLog Base(bool success)
        {
            return new ActionLog
            {
                Success = success
            };
        }
        public ILog Build(bool success)
        {
            Log = Base(success);
            return this;
        }
        public ILog User(object user)
        {
            Log.UserLog = _mapper.Mapper.Map<UserLog>(user);
            return this;
        }
        public ILog Complements(string description)
        {
            Log.Description = description;
            return this;
        }



        public async void Add()
        {
            if (Log == null)
                throw new Exception("Build log, before save");

            await _repo.Add(Log);
        }

        public async void Add(ActionLog log)
        {
            await _repo.Add(Log);
        }



    }
}
