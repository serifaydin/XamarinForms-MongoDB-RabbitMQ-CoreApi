using MLTP.Infrastructure.Queue.DataModels;

namespace MLTP.Jobs.MailConsumer
{
    public class MailProcess
    {
        private static MailProcess mailProcess;
        static object _lockObject = new object();

        private MailProcess() { }

        public static MailProcess createAsSingleton()
        {
            lock (_lockObject)
                return mailProcess ?? (mailProcess = new MailProcess());
        }

        public string MailSend(EmailModel emailModel)
        {
            string responseResult = "";
            //TODO Mail Server
            return responseResult;
        }
    }
}