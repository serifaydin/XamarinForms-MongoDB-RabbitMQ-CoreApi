using RabbitMQ.Client;

namespace MLTP.Infrastructure.Queue.RabbitMQSetting
{
    public class RabbitMQConnection
    {
        public IConnection GetRabbitMQConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory
            {
                HostName = RabbitMQModel.Hostname,
                VirtualHost = RabbitMQModel.Virtualname,
                UserName = RabbitMQModel.Username,
                Password = RabbitMQModel.Password
            };

            return connectionFactory.CreateConnection();
        }
    }
}