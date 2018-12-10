using System.Collections.Generic;

namespace MLTP.Infrastructure.Queue.DataModels
{
    public class SmsModel
    {
        public List<string> Phones { get; set; }
        public string Message { get; set; }
    }
}