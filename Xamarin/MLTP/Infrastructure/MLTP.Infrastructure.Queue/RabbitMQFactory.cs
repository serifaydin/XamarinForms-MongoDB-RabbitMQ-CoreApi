namespace MLTP.Infrastructure.Queue
{
    public abstract class RabbitMQFactory<T>
    {
        public abstract void Producer(T model, string QueueRouteKey);
    }
}