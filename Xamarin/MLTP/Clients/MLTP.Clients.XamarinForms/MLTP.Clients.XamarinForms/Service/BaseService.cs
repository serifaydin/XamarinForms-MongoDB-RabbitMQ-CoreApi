using System.Net.Http;
using System.Threading.Tasks;

namespace MLTP.Clients.XamarinForms.Service
{
    public abstract class BaseService
    {
        protected async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
    }
}