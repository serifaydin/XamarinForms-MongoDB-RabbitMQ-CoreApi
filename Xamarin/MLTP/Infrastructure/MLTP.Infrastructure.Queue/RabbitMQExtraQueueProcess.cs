using MLTP.Infrastructure.Queue.RabbitMQSetting;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;

namespace MLTP.Infrastructure.Queue
{
    public class RabbitMQExtraQueueProcess
    {
        private static RabbitMQExtraQueueProcess rabbitMQExtraQueueProcess;
        static object _lockObject = new object();
        private RabbitMQExtraQueueProcess() { }

        public static RabbitMQExtraQueueProcess createAsSingleton()
        {
            lock (_lockObject)
                return rabbitMQExtraQueueProcess ?? (rabbitMQExtraQueueProcess = new RabbitMQExtraQueueProcess());
        }

        public int GetRetryAttempts(IBasicProperties properties)
        {
            if (properties.Headers == null || properties.Headers.ContainsKey(RabbitMQModel.QueueHeadername) == false)
                return 0;

            object val = properties.Headers[RabbitMQModel.QueueHeadername];

            if (val == null)
                return 0;

            return Convert.ToInt32(val);
        }

        public IDictionary<string, object> CopyMessageHeaders(IDictionary<string, object> existingProperties)
        {
            var newProperties = new Dictionary<string, object>();
            if (existingProperties != null)
            {
                var enumerator = existingProperties.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    newProperties.Add(enumerator.Current.Key, enumerator.Current.Key);
                }
            }
            return newProperties;
        }

        public void SetRetryAttempts(IBasicProperties properties, int newAttempts)
        {
            if (properties.Headers.ContainsKey(RabbitMQModel.QueueHeadername))
                properties.Headers[RabbitMQModel.QueueHeadername] = newAttempts;
            else
                properties.Headers.Add(RabbitMQModel.QueueHeadername, newAttempts);
        }
    }
}