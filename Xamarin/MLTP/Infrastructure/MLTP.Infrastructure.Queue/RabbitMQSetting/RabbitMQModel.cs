namespace MLTP.Infrastructure.Queue.RabbitMQSetting
{
    public static class RabbitMQModel
    {
        public const string Hostname = "localhost";
        public const string Virtualname = "mltp";
        public const string Username = "admin";
        public const string Password = "123";
        public const string Exchangename = "mltp.direct";
        public const string QueueHeadername = "RETRY-COUNT";
        public const int RetryCount = 10;
    }
}