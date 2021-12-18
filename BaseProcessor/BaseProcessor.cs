using System.Net;
using System.Reflection;
using System.Xml;

namespace BaseProcessor
{
    public abstract class BaseProcessor
    {
        public virtual string SendRequest(string url)
        {
            HttpWebRequest webClient = WebRequest.CreateHttp(url);
            string response = "";
            using (WebClient client = new WebClient())
            {
                PrepareWebClient(webClient);
                using (HttpWebResponse webResponse = (HttpWebResponse)webClient.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        response = reader.ReadToEnd();
                        reader.Close();
                    }
                    webResponse.Close();
                }
            }
            return response;  
        }
        public async Task<string> SendRequestAsync(string url)
        {
            HttpWebRequest webClient = WebRequest.CreateHttp(url);
            string response = "";
           
            using (WebClient client = new WebClient())
            {
                PrepareWebClient(webClient);
                
                
                using (var webResponse = (HttpWebResponse)await Task.Factory
                    .FromAsync<WebResponse>(webClient.BeginGetResponse,
                                            webClient.EndGetResponse,
                                            null).ConfigureAwait(false))
                {
                    using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        response = await reader.ReadToEndAsync();
                        reader.Close();
                    }
                    webResponse.Close();
                }
            }
            return response;
        }


        protected virtual HttpWebRequest PrepareWebClient(HttpWebRequest webClient)
        {
            return webClient;
        }
    }
    public class Configurator
    {
        private XmlDocument config;

        public Configurator()
        {
            config = new XmlDocument();
            config.Load(Assembly.GetCallingAssembly().CodeBase + ".config"); 
        }

        public string GetSetting(string key)
        {
            string value = config.SelectSingleNode("//add[@key='" + key + "']").Attributes["value"].InnerText;
            return value;
        }
    }
}