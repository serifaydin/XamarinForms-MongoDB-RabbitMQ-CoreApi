using MLTP.Clients.XamarinForms.Common;
using MLTP.Clients.XamarinForms.Models;
using MLTP.Clients.XamarinForms.Models.Common;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MLTP.Clients.XamarinForms.Service
{
    public class CommonService : BaseService
    {
        public async Task<ResponseItem> UserLogin(string userName, string Password)
        {
            HttpClient client = await GetClient();
            string url = ApiConfiguration.WebApiUrl + "Common/" + "Login/" + userName + "/" + Password;

            var result = await client.GetStringAsync(url);
            var responseItem = JsonConvert.DeserializeObject<ResponseItem>(result);
            responseItem.Data = JsonConvert.DeserializeObject<AuthenticateModel>(responseItem.Data.ToString());
            return responseItem;
        }

        public async Task<ResponseItem> AddUserDevice(AddUserDeviceRequestModel model)
        {
            HttpClient client = await GetClient();
            string url = ApiConfiguration.WebApiUrl + "Common/" + "AddUserDevice";

            var responce = await client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(model),
               Encoding.UTF8, "application/json"));
            var mobileResult = await responce.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseItem>(mobileResult);
            return result;
        }
    }
}