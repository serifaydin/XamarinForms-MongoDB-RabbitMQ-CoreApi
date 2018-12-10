using System.Collections.Generic;

namespace MLTP.Clients.XamarinForms.Models.MessageDelivery
{
    public class EmailModel
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> To { get; set; }
        public IEnumerable<string> Bcc { get; set; }
        public IEnumerable<string> CC { get; set; }
        public string FileName { get; set; }
    }
}