namespace Financ.API.Services.Log
{
    public interface ILog
    {
        void Add();
        void Add(ActionLog log);

        ILog Build(bool success);
        ILog User(object user);
        ILog Complements(string description);
    }
}
