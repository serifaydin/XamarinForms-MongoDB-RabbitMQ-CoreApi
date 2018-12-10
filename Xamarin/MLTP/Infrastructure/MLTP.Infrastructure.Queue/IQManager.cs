using MLTP.Infrastructure.Queue.DataModels;

namespace MLTP.Infrastructure.Queue
{
    public interface IQManager
    {
        void SmsSend(SmsModel model);
        void EmailSend(EmailModel model);
    }
}