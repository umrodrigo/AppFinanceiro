using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using static Financ.Api.Services.Log.LogDependencyInjectionExtensions;

namespace Financ.Api.Services.Log
{
    public interface ILogRepository
    {
        IMongoCollection<ActionLog> Actions { get; }
        Task Add(ActionLog log);
    }
    public class LogRepository : ILogRepository
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<ActionLog> _actions;

        public IMongoCollection<ActionLog> Actions => _actions;

        public LogRepository(LogSettings config)
        {
            var setting = MongoClientSettings.FromConnectionString(config.URIconnection);
            setting.ApplicationName = "Financ-API";
            setting.MaxConnectionPoolSize = 30;

            ConventionRegistry.Register("Ignore null values", new ConventionPack { new IgnoreIfNullConvention(true) }, t => true);

            _client = new MongoClient(setting);
            _database = _client.GetDatabase(config.Database);
            _actions = _database.GetCollection<ActionLog>(config.CollectionActionLog);
        }

        public async Task Add(ActionLog log)
        {
            try
            {
                await _actions.InsertOneAsync(log);
            }
            catch (Exception)
            {

            }
        }
    }
}
