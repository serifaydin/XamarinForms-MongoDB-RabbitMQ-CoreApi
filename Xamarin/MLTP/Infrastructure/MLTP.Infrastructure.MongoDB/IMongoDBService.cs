namespace MLTP.Infrastructure.MongoDB
{
    public interface IMongoDBService
    {
        void Create(AppModel model);
    }
}