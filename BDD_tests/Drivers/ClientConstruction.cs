using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BDD_tests.Drivers
{
    public class ClientConstruction
    {
        private HttpClient client = new HttpClient(); 

        public ClientConstruction()
        {
            client.BaseAddress = new System.Uri("https://localhost:7214/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<HttpResponseMessage> SendRequest(HttpRequestMessage request) => await client.SendAsync(request);
    }
}
