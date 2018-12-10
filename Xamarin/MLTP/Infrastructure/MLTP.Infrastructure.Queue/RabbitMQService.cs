using MLTP.Infrastructure.Queue.RabbitMQSetting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace MLTP.Infrastructure.Queue
{
    public class RabbitMQService<T> : RabbitMQFactory<T>
    {
        public override void Producer(T model, string QueueRouteKey)
        {
            string mongodbMessage = "";
            try
            {
                var rabbitMQConnectionService = new RabbitMQConnection();

                using (var connection = rabbitMQConnectionService.GetRabbitMQConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        string message = JsonConvert.SerializeObject(model);

                        mongodbMessage = "Model : " + model.GetType().Name + " # Data : " + message + " # ";

                        var publicationAddress = new PublicationAddress(ExchangeType.Topic, RabbitMQModel.Exchangename, QueueRouteKey);

                        byte[] body = Encoding.UTF8.GetBytes(message);
                        channel.BasicPublish(publicationAddress, null, body);

                        mongodbMessage += QueueRouteKey + " 'e EKLENDİ";

                        channel.Close();
                    }

                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                mongodbMessage += " # ERROR : " + ex;
            }
        }
    }
}