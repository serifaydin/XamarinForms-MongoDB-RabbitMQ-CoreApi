using MLTP.Clients.XamarinForms.Common;
using MLTP.Clients.XamarinForms.Models;
using MLTP.Clients.XamarinForms.Models.MessageDelivery;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MLTP.Clients.XamarinForms.Service
{
    public class MessageDeliveryService : BaseService
    {
        public async Task<ResponseItem> EMailQueue(EmailModel model)
        {
            HttpClient client = await GetClient();
            string url = ApiConfiguration.WebApiUrl + "MessageDelivery/" + "EMailQueue";

            var responce = await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(model),
               Encoding.UTF8, "application/json"));
            var mobileResult = await responce.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseItem>(mobileResult);
            return result;
        }

        public async Task<ResponseItem> SmsQueue(SmsModel model)
        {
            HttpClient client = await GetClient();
            string url = ApiConfiguration.WebApiUrl + "MessageDelivery/" + "SmsQueue";

            var responce = await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(model),
               Encoding.UTF8, "application/json"));
            var mobileResult = await responce.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseItem>(mobileResult);
            return result;
        }
    }
}