using System.Net;
using System.Reflection;
using System.Xml;

namespace BaseProcessor
{
    public abstract class BaseApiProcessor : ISideService
    {
        public abstract List<ProviderResponse> GetAll(string text);
        public abstract ProviderResponse GetInfo(string id);

        public virtual string SendRequest(string url)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
 
        } 
    }
}