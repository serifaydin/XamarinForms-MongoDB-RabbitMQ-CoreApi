using MLTP.Infrastructure.Queue.DataModels;

namespace MLTP.Infrastructure.Queue
{
    public class RabbitMQProducerManager : IQManager
    {
        private RabbitMQService<EmailModel> emailService = null;
        private RabbitMQService<SmsModel> smsService = null;

        public void EmailSend(EmailModel model)
        {
            emailService = new RabbitMQService<EmailModel>();
            emailService.Producer(model, "EmailRouteKey");
        }

        public void SmsSend(SmsModel model)
        {
            smsService = new RabbitMQService<SmsModel>();
            smsService.Producer(model, "SmsRouteKey");
        }
    }
}