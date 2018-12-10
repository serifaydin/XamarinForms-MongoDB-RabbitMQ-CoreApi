using MLTP.Infrastructure.MongoDB;
using MLTP.Infrastructure.Queue;
using MLTP.Infrastructure.Queue.DataModels;
using MLTP.Infrastructure.Queue.RabbitMQSetting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace MLTP.Jobs.MailConsumer
{
    class Program
    {
        public static int currentRetryCount { get; set; }

        static MongoDBService mongoDbService = new MongoDBService();
        static void Main(string[] args)
        {
            RabbitMQExtraQueueProcess QueueExtraProcess = RabbitMQExtraQueueProcess.createAsSingleton();

            Console.WriteLine("Mail Consumer");
            var rabbitMQService = new RabbitMQConnection();

            string mongodbMessage = "";

            using (var connection = rabbitMQService.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.BasicQos(0, 1, false);
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        mongodbMessage = "";
                        EmailModel emailModel = new EmailModel();

                        try
                        {
                            string message = Encoding.UTF8.GetString(ea.Body);
                            emailModel = JsonConvert.DeserializeObject<EmailModel>(message);

                            string responseResult = "";

                            MailProcess mailProcess = MailProcess.createAsSingleton();
                            responseResult = mailProcess.MailSend(emailModel);

                            channel.BasicAck(ea.DeliveryTag, false);

                            mongodbMessage += " Mail Api Result : " + responseResult + " - Mail Gönderildi ve Queue'den kaldırıldı.";
                        }
                        catch (Exception ex)
                        {
                            currentRetryCount = QueueExtraProcess.GetRetryAttempts(ea.BasicProperties);

                            mongodbMessage += " - RetryCount : " + currentRetryCount + " - Hata : " + ex.ToString();

                            if (currentRetryCount < RabbitMQModel.RetryCount)
                            {
                                currentRetryCount++;

                                var properties = channel.CreateBasicProperties();
                                properties.Headers = QueueExtraProcess.CopyMessageHeaders(ea.BasicProperties.Headers);
                                QueueExtraProcess.SetRetryAttempts(properties, currentRetryCount);
                                channel.BasicPublish(ea.Exchange, ea.RoutingKey, properties, ea.Body);
                                channel.BasicAck(ea.DeliveryTag, false);
                            }
                            else
                            {
                                channel.BasicReject(ea.DeliveryTag, false);
                                mongodbMessage += currentRetryCount + " - Email Queue' den silindi";
                            }
                        }

                        Console.WriteLine(mongodbMessage);
                        AppModel modelMongo = new AppModel
                        {
                            Name = emailModel.Subject,
                            Description = mongodbMessage,
                            Date = DateTime.Now
                        };
                        mongoDbService.Create(modelMongo);
                    };

                    channel.BasicConsume("EmailQueue", false, consumer);

                    Console.ReadLine();
                }
            }
        }
    }
}
