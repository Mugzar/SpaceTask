using BaseProcessor;
using Newtonsoft.Json;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace IMDBprocessor
{
    public class MovieProcessor:BaseProcessor.BaseProcessor
    {
        protected Configurator configuration = new Configurator();
        protected readonly string Host;
        protected readonly string ApiKey;
        protected readonly int Timeout;

        public MovieProcessor()
        {
            Host= configuration.GetSetting("Host");
            ApiKey = configuration.GetSetting("ApiKey");
            Timeout = int.Parse(configuration.GetSetting("Timeout"));
        }

        public List<IMDBmovieResponse> GetAll(string expression)
        {
            List<IMDBmovieResponse> movies = new List<IMDBmovieResponse>();
            string response = SendRequest($"{Host}/SearchMovie/{ApiKey}/{expression}");
            IMDBsearchResponse searchResponse =
                JsonConvert.DeserializeObject<IMDBsearchResponse>(response);
            foreach (ResultItem m in searchResponse.Results)
            {
                movies.Add(GetInfo(m.Id));
            } 
            return movies;
        } 
        public IMDBmovieResponse GetInfo(string title)
        {
            string response = SendRequest($"{Host}/Title/{ApiKey}/{title}");
            IMDBmovieResponse movieResponse =
                JsonConvert.DeserializeObject<IMDBmovieResponse>(response);
            return movieResponse;
        }
        public IMDBmovieResponse GetPoster(string title)
        {
            string response = SendRequest($"{Host}/Posters/{ApiKey}/{title}");
            IMDBmovieResponse IMDBmovieResponse =
                JsonConvert.DeserializeObject<IMDBmovieResponse>(response);
            return IMDBmovieResponse;
        }
        public IMDBmovieResponse GetDescription(string title)
        {
            string response = SendRequest($"{Host}/Wikipedia/{ApiKey}/{title}");
            IMDBmovieResponse IMDBmovieResponse =
                JsonConvert.DeserializeObject<IMDBmovieResponse>(response);
            return IMDBmovieResponse;
        }
        protected override HttpWebRequest PrepareWebClient(HttpWebRequest webClient)
        {
            webClient.Timeout = Timeout;
            return webClient;
        }
    }
}