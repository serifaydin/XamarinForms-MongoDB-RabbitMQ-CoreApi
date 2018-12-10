using MLTP.Infrastructure.Queue.DataModels;

namespace MLTP.Jobs.SmsConsumer
{
    public class SmsProcess
    {
        private static SmsProcess smsProcess;
        static object _lockObject = new object();

        private SmsProcess() { }

        public static SmsProcess createAsSingleton()
        {
            lock (_lockObject)
                return smsProcess ?? (smsProcess = new SmsProcess());
        }

        public string SmsSend(SmsModel smsModel)
        {
            string responseResult = "";
            string phones = GetPhone(smsModel);


            return responseResult;
        }

        public string GetPhone(SmsModel smsModel)
        {
            string _phones = "";
            foreach (string smsPhone in smsModel.Phones)
            {
                _phones += smsPhone + "~";
            }

            return _phones;
        }
    }
}