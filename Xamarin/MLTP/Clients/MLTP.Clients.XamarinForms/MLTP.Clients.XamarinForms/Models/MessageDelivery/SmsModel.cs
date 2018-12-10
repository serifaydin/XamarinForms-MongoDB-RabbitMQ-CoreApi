using System.Collections.Generic;

namespace MLTP.Clients.XamarinForms.Models.MessageDelivery
{
    public class SmsModel
    {
        public List<string> Phones { get; set; }
        public string Message { get; set; }
    }
}