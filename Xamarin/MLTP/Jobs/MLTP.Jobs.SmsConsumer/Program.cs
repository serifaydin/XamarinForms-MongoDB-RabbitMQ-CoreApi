using MLTP.Infrastructure.Queue;
using MLTP.Infrastructure.Queue.DataModels;
using MLTP.Infrastructure.Queue.RabbitMQSetting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLTP.Jobs.SmsConsumer
{
    class Program
    {
        public static int currentRetryCount { get; set; }

        static void Main(string[] args)
        {
            RabbitMQExtraQueueProcess QueueExtraProcess = RabbitMQExtraQueueProcess.createAsSingleton();

            Console.WriteLine("Sms Consumer");
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
                        try
                        {
                            string message = Encoding.UTF8.GetString(ea.Body);
                            SmsModel smsModel = JsonConvert.DeserializeObject<SmsModel>(message);

                            string phones = ListofString(smsModel.Phones);

                            mongodbMessage = "Phones : " + phones;

                            string responseResult = "";

                            SmsProcess smsProcess = SmsProcess.createAsSingleton();
                            responseResult = smsProcess.SmsSend(smsModel);

                            channel.BasicAck(ea.DeliveryTag, false);

                            mongodbMessage += " Sms Api Result : " + responseResult + " - Sms Gönderildi ve Queue'den kaldırıldı.";
                        }
                        catch (Exception ex) //Email Consumer ile aynı yol izleniyor.
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
                    };

                    channel.BasicConsume("SmsQueue", false, consumer);

                    Console.ReadLine();
                }
            }
        }

        private static string ListofString(IEnumerable<string> array)
        {
            string _string = "";
            foreach (string item in array)
            {
                _string += item + " - ";
            }
            return _string;
        }
    }
}
